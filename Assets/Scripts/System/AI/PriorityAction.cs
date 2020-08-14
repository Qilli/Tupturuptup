using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PriorityAction : BaseAction, IComparable<PriorityAction>
{
    public int priority = 1;
    public override bool act(StateController stateController)
    {
        return true;
    }

    public virtual int getPriority()
    {
        return priority;
    }

    public int CompareTo(PriorityAction obj)
    {
        if (obj.getPriority() < this.getPriority()) return -1;
        else if (obj.getPriority() > this.getPriority()) return 1;
        else return 0;
    }
}
