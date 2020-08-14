﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EngineAssets/System/ObjectsManager")]
public class ObjectsManager : ScriptableObject
{
    public ListenersControler<BaseObject> listeners = new ListenersControler<BaseObject>();
    public bool updateEnabled = true;
    public virtual void onUpdate()
    {
        float currentDelta = Timer.deltaTime;
        if (updateEnabled && Timer.TimeScale != 0)
        {
          /*  foreach (BaseObject o in listeners.listeners)
            {
                o.onUpdate(currentDelta);
            }*/

            for(int a=0; a<listeners.listeners.Count;++a)
            {
                listeners.listeners[a].onUpdate(currentDelta);
            }
        }
    }

    public virtual void onChangeState(GameSystem.GameState newState)
    {
        foreach (BaseObject o in listeners.listeners)
        {
            o.onChangeState(newState);
        }
    }

    public virtual void onDestroy()
    {

    }

    public virtual void onInit()
    {
        foreach (BaseObject o in listeners.listeners)
        {
            o.init();
        }
    }

    public virtual void onFixedUpdate()
    {
        float currentDelta = Timer.fixedDeltaTime;
        if (updateEnabled && Timer.TimeScale != 0)
        {
         /*   foreach (BaseObject o in listeners.listeners)
            {
                o.onFixedUpdate(currentDelta);
            }*/

            for (int a = 0; a < listeners.listeners.Count; ++a)
            {
                listeners.listeners[a].onFixedUpdate(currentDelta);
            }
        }
    }
}
