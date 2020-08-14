using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarController : BaseObject
{
    public AStarSystem system;
    public virtual void updateAStarMap()
    {
        system.updateNodeMap();  
    }

    public override void init()
    {
        if (inited == false)
        {
            system.initSystem();
            inited = true;
        }
    }


}