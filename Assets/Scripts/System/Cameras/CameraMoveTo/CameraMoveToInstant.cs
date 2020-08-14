using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveToInstant : CameraMoveTo
{
    public override void startMoveTo(Transform t, Vector3 start, Vector3 end, Camera targetCam, float targetOrthoSize)
    {
        t.position = end;
        isMoving_ = false;
        targetCam.orthographicSize = targetOrthoSize;
    }

}
