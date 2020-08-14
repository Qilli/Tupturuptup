using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : BaseObject
{
    public SimpleCamera2D baseCamera;
    public virtual Camera getMainNativeCamera()
    {
        return Camera.main;
    }

    public virtual SimpleCamera2D getMainCamera()
    {
        return baseCamera;
    }


}
