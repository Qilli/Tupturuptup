using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "EngineAssets/Input/InputSystem")]
public class InputSystem : ScriptableObject
{
    private InputForGame inputControl;

    public InputForGame Input
    {
        get
        {
            return inputControl;
        }
    }


    public virtual void init()
    {
        inputControl = new InputForGame();
    }

    public virtual void enableSystem()
    {
        inputControl.Enable();
    }

    public virtual void disableSystem()
    {
        inputControl.Disable();
    }
}
