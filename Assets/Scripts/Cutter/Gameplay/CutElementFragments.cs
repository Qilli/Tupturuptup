using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutElementFragments : BaseObject
{
    [Header("Base")]
    public CutElementObject parent;
    public Line.LineDirection directionFor;
    public float lifeTime = 2.0f;
    private float timer = 0;

    public override void onFixedUpdate(float fixedDelta)
    {
        base.onFixedUpdate(fixedDelta);
        timer += fixedDelta;
        if(timer>=lifeTime)
        {
            parent.changeElemState(CutElementObject.ElementState.EMPTY);
            Destroy(gameObject);
        }
    }
}
