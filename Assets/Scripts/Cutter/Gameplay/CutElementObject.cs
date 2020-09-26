using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutElementObject : BaseObject
{
    public enum ElementState
    {
        EMPTY,
        LOCKED,
        ACTIVE
    }
    [Header("Base")]
    public ElementState elemState;
    [Header("Element")]
    public CutElement objDefinition;

    [Header("Visual")]
    public SpriteRenderer elemSprite;

    public override void init()
    {
        base.init();
        changeElemState(ElementState.ACTIVE);
    }

    public void tryCut(Line l)
    {
        if(elemState == ElementState.ACTIVE)
        {
            GameObject pref = objDefinition.getCutPrefabForCut(l.direction);
            GameObject.Instantiate(pref, Vector3.zero, Quaternion.identity, this.transform);
            changeElemState(ElementState.EMPTY);
        }
    }

    public void changeElemState(ElementState state_)
    {
        elemState = state_;
        if(state_== ElementState.EMPTY)
        {
            elemSprite.sprite = null;
        }
        else if(state_ == ElementState.ACTIVE)
        {
            elemSprite.sprite = objDefinition.baseStaticVisual;
        }
    }

}
