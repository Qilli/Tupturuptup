using System.Collections.Generic;
using UnityEngine;

public class StateController : BaseObject
{
    public List<PriorityCommand> commands = new List<PriorityCommand>();
    [Header("States")]
    public State currentState;
    public State brainState;
    public State outOfControl;
    private bool aiActive = true;
    [HideInInspector]
    public PriorityCommand currentCommand = null;
    private bool forceExitCurrentState = false;
    protected bool returnCommandToPool_ = false;
    public PriorityCommand CurrentStateCommand { get; set; } = null;

    public virtual bool isForcedToExitActive() { return forceExitCurrentState; }
    public virtual void setForceToExit() { forceExitCurrentState = true; }
    public virtual bool returnCommandToPool() { return returnCommandToPool_; }
    public PriorityCommand getCurrentCommand() { return currentCommand; }
    public bool LastCommandFullyDone { get; set; }

    public bool isInBrainState() { return currentState == brainState; }

    public virtual void addCommand(PriorityCommand c, bool cancelingCommand = false, bool cancelTheSameActionsInRow = false)
    {
        if (cancelingCommand == true)
        {
            cancelAllActions();
        }
        else if (cancelTheSameActionsInRow)
        {
            //we cancel actions which are the same as currently added but only until we meet something different or the end of commands
            cancelUntil(c.getCommandType());
        }
        commands.Add(c);
    }

    public CommandType getCommandAt(int index)
    {
        if (commands.Count > index && index >= 0)
        {
            return commands[index].getCommandType();
        }
        return CommandType.NONE;
    }

    public virtual void tryCancelByMarks(int index)
    {
        PriorityCommand c = commands[index];
        if (c.markIndex == -1)
        {
            cancelCommand(index);
        }
    }

    public virtual void cancelCommand(int index)
    {
        //if it;s current command, check if it's on going, if yes, force state cancel too
        if (index == 0)
        {
            if (currentCommand != null && !(currentCommand.currentCommandResult == CommandResult.NEW || currentCommand.currentCommandResult == CommandResult.FAILED))
            {
                if (currentState != brainState)
                {
                    forceExitCurrentState = true;
                    currentCommand.onForceToExit();
                }

            }


            //currentCommand.onCancel();


            currentCommand = null;
        }
        else
        {
            commands[index].onCancel();

        }
        commands.RemoveAt(index);
    }

    public virtual void cancelCommand(PriorityCommand cmd)
    {
        //if it;s current command, check if it's on going, if yes, force state cancel too
        if (cmd == currentCommand)
        {
            if (currentCommand != null && !(currentCommand.currentCommandResult == CommandResult.NEW || currentCommand.currentCommandResult == CommandResult.FAILED))
            {
                if (currentState != brainState)
                {
                    forceExitCurrentState = true;
                    currentCommand.onForceToExit();
                }
            }
            currentCommand = null;
        }
        else
        {
            cmd.onCancel();
        }
        commands.Remove(cmd);
    }

    public virtual void cancelUntil(CommandType type_)
    {
        if (currentCommand != null && currentCommand.getCommandType() == type_)
        {
            //cancel current command
            if (currentState != brainState)
            {
                forceExitCurrentState = true;
            }
            cancelCommand(currentCommand);
        }
        else
        {
            return;
        }

        List<PriorityCommand> indexesForErase = new List<PriorityCommand>();
        foreach (PriorityCommand c in commands)
        {
            if (c.getCommandType() == type_)
            {
                indexesForErase.Add(c);
            }
            else
            {
                break;
            }
        }

        if (indexesForErase.Count > 0)
        {
            foreach (PriorityCommand c in indexesForErase)
            {
                cancelCommand(c);
            }
        }
        indexesForErase = null;

    }

    public virtual void cancelAllActions()
    {
        // commands.Clear();
        currentCommand = null;
        foreach (PriorityCommand c in commands)
        {
            if (c.markIndex == -1)
            {
                c.onCancel();
            }
        }
        commands.Clear();
        if (currentState != brainState)
        {
            forceExitCurrentState = true;
        }
    }

    public virtual void instantOutOfControl()
    {
        changeControllerState(outOfControl);
        //check if we had multi
        if (currentCommand != null)
        {
            if (currentCommand.currentCommandResult != CommandResult.NEW)
            {
                //command to erase
                commands.RemoveAt(0);
                currentCommand = null;
                getNextCommand();
            }
        }
    }

    public override void onFixedUpdate(float delta)
    {
        base.onUpdate(delta);
        if (!aiActive) return;

        if (currentState == brainState)
        {
            updateCommands();
        }
        currentState.updateState(this);

    }

    public virtual void changeControllerState(State newState)
    {
        if (currentState != newState)
        {
            forceExitCurrentState = false;
            currentState.onExitState(this);
            currentState = newState;
            currentState.onEnterState(this);
        }
    }

    public virtual void getNextCommand()
    {
        if (commands.Count != 0)
        {
            //commands.Sort();
            currentCommand = commands[0];
        }
    }

    public virtual void updateCommands()
    {

        if (currentCommand != null && commands.Count == 0)
        {
            currentCommand = null; // pusty command z ciul wie czego
        }


        if (currentCommand != null)
        {
            if (currentCommand.currentCommandResult == CommandResult.DONE)
            {
                if (returnCommandToPool_ && LastCommandFullyDone == false)
                {
                    //jeśli command został wykonany ale state zwrócił z return to pool
                    //to command wraca do pool wszystkich zadan i ponownie moze zostac zabrany
                    currentCommand.resetCommandResult();
                    commands.Remove(currentCommand);
                    //próbujemy odesłac command z powrotem do task managera

                    //nie da się obecnie wykonać tej akcji, wracamy z akcja do puli not assigned
                    //resetujemy rezultat akcji
                    currentCommand.resetCommandResult();
                    currentCommand.onReturnToPool();


                    currentCommand = null;
                }
                else
                {
                    currentCommand.commandEnd();
                    commands.RemoveAt(0);
                    currentCommand = null;
                    getNextCommand();
                }
            }
            else if (currentCommand.currentCommandResult == CommandResult.WORKING)
            {
                if (returnCommandToPool_ && LastCommandFullyDone == false)
                {
                    //jeśli command został wykonany ale state zwrócił z return to pool
                    //to command wraca do pool wszystkich zadan i ponownie moze zostac zabrany
                    currentCommand.resetCommandResult();
                    commands.RemoveAt(0);
                    //próbujemy odesłac command z powrotem do task managera

                    //nie da się obecnie wykonać tej akcji, wracamy z akcja do puli not assigned
                    //resetujemy rezultat akcji
                    currentCommand.resetCommandResult();
                    currentCommand.onReturnToPool();


                    currentCommand = null;
                }
            }
            else if (currentCommand.currentCommandResult == CommandResult.FAILED)
            {
                // currentCommand.commandEnd();
                // currentCommand.onCancel();
                currentCommand.resetCommandResult();
                commands.RemoveAt(0);
                currentCommand = null;
            }
            else if (currentCommand.currentCommandResult == CommandResult.FAILED_CANCEL)
            {
                currentCommand.commandEnd();
                currentCommand.onCancel();
                commands.RemoveAt(0);
                currentCommand = null;
            }

            if (currentCommand != null)
            {
                currentCommand.execute();
            }

            /*     CommandResult res = currentCommand.execute();
             if(res == CommandResult.DONE || res == CommandResult.FAILED)
             {
                 //end of action
                 //remove from list
                 commands.RemoveAt(0);
                 currentCommand = null;
                 getNextCommand();
             }*/


            //resetujemy powrót do pool
            //jesli mialo wrocic to wrocila w sprawdzaniu rezulatu ostatniego commanda

            returnCommandToPool_ = false;
            LastCommandFullyDone = false;

        }
        else
        {
            getNextCommand();
        }
    }
}
