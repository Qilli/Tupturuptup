using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class PriorityCommand : Command, IComparable<PriorityCommand>
{
    public StateController stateCtrl;
    public int priority = 1;
    public CommandResult currentCommandResult = CommandResult.NEW;
    public delegate void onCommandState(CommandResult res, bool finished);
    public onCommandState stateChange;
    public int markIndex = -1;



    public override CommandResult execute()
    {
        currentCommandResult = CommandResult.DONE;
        changeCommandResult(CommandResult.DONE);
        return CommandResult.DONE;
    }

    public virtual void onReturnToPool()
    {

    }

    public virtual void resetCommandResult()
    {
        currentCommandResult = CommandResult.NEW;
    }

    public virtual void addDelegate(onCommandState newDel)
    {
        stateChange += newDel;
    }

    public virtual void removeDelegate(onCommandState delDel)
    {
        stateChange -= delDel;
    }

    public virtual void changeCommandResult(CommandResult res)
    {
        currentCommandResult = res;
        stateChange?.Invoke(res, false);
    }

    public virtual void commandEnd()
    {
        stateChange?.Invoke(currentCommandResult, true);
    }

    public int CompareTo(PriorityCommand obj)
    {
        if (obj.getPriority() < this.getPriority()) return -1;
        else if (obj.getPriority() > this.getPriority()) return 1;
        else return 0;
    }
    public virtual int getPriority()
    {
        return priority;
    }

    public override void onCancel() { }

    public virtual void onForceToExit()
    {

    }

    public override CommandType getCommandType()
    {
        return CommandType.DEFAULT;
    }

}


