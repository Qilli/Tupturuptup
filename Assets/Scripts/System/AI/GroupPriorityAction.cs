using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupPriorityAction : PriorityAction
{
    public BaseAction[] actionsList;
    //
    public int currentIndex = 0;
    public bool sequencial = true;

    public override bool act(StateController stateController)
    {
        if (sequencial)
        {
            if (currentIndex >= actionsList.Length) { return true; }//action finished
            bool res = actionsList[currentIndex].act(stateController);
            if (res && currentIndex == actionsList.Length - 1)
            {
                return true; //all finished
            }
            else if(res)
            {
                currentIndex++;
            }
            return false; //part done but not all
        }
        else
        {
            foreach(BaseAction a in actionsList)
            {
                if (!a.act(stateController)) return false;
            }
            return true;
        }
    }
}
