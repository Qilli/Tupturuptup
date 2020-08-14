using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupPriorityCommand : PriorityCommand
{
    public PriorityCommand[] commandsList;
    //
    public int currentIndex = 0;
    public bool sequencial = true;

    public override CommandType getCommandType()
    {
        return commandsList[commandsList.Length - 1].getCommandType();
    }

    public override void resetCommandResult()
    {
        base.resetCommandResult();
        foreach(PriorityCommand c in commandsList)
        {
            c.resetCommandResult();
        }
        currentIndex = 0;
    }

    public override void onReturnToPool()
    {
        base.onReturnToPool();
        foreach (PriorityCommand c in commandsList)
        {
            c.onReturnToPool();
        }
    }

    public override void onCancel()
    {
        base.onCancel();
        foreach(PriorityCommand c in commandsList)
        {
            c.onCancel();
        }
    }

    public override void onForceToExit()
    {
        base.onForceToExit();
        foreach (PriorityCommand c in commandsList)
        {
            c.onForceToExit();
        }
    }

    public override CommandResult execute()
    {
        if (sequencial)
        {
            CommandResult res = commandsList[currentIndex].execute();
            if (res == CommandResult.FAILED)
            {
                changeCommandResult(CommandResult.FAILED);
                return currentCommandResult;
            }
            else if(res== CommandResult.FAILED_CANCEL)
            {
                changeCommandResult(CommandResult.FAILED_CANCEL);
                return currentCommandResult;
            }
            else
            {
                if (res == CommandResult.DONE)
                {
                    currentIndex++;
                    if (currentIndex >= commandsList.Length) {
                        changeCommandResult(CommandResult.DONE);
                        return CommandResult.DONE;
                    }
                }
                changeCommandResult( CommandResult.WORKING);
                return CommandResult.WORKING;
            }
        }
        else
        {
            bool hasWorking = false;
            foreach (Command a in commandsList)
            {
                CommandResult r = a.execute();
                if (r == CommandResult.FAILED)
                {
                    changeCommandResult(CommandResult.FAILED);
                    return CommandResult.FAILED;
                }
                else if (r == CommandResult.FAILED_CANCEL)
                {
                    changeCommandResult(CommandResult.FAILED_CANCEL);
                    return currentCommandResult;
                }
                else if (r == CommandResult.WORKING) hasWorking = true;
            }
            if (hasWorking) { changeCommandResult(CommandResult.WORKING); ; }
            else { changeCommandResult(CommandResult.DONE); ; }
            return currentCommandResult;
        }
    }
}
