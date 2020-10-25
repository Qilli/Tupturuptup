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

    private SpriteRenderer elemSprite;
    private Rigidbody2D rigid;

    public override void init()
    {
        base.init();
        if (inited == false)
        {
            inited = true;
            elemSprite = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();
            changeElemState(ElementState.ACTIVE);
        }
    }

    public void tryCut(Line l)
    {
        if(elemState == ElementState.ACTIVE)
        {
            GameObject pref = objDefinition.getCutPrefabForCut(l.direction);
            GameObject instantiated=GameObject.Instantiate(pref, this.transform.position, Quaternion.identity, this.transform);
            CutElementFragments fragments = instantiated.GetComponent<CutElementFragments>();
            fragments.parent = this;
            changeElemState(ElementState.LOCKED);
        }
    }

    public void setElemDefinition(CutElement elem)
    {
        objDefinition = elem;
        changeElemState(ElementState.ACTIVE);
    }

    public void setInitParams(Vector2 iPos, Vector2 iForce,float iAngularForce,FruitsSpawnerSettings s)
    {
        transform.position = new Vector3(iPos.x, iPos.y, 0);

        //dodajemy siłe dla uzyskania ruchu
        rigid.AddForce(iForce, s.forceMode);
        rigid.AddTorque(iAngularForce, s.forceMode);
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
        else if(state_ == ElementState.LOCKED)
        {
            elemSprite.sprite = null;
        }
    }

}
