using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
[System.Serializable]
public class EventVector2: UnityEvent<Vector2> { }
[System.Serializable]
public class EventVector2Int : UnityEvent<Vector2,int> { }

public class OnHoverElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public EventVector2 onEnter;
    public int index = 0;
    public EventVector2Int onEnterIndex;
    public UnityEvent onExit;
    public UnityEvent onUpdate;

    private bool isOver = false;

    public virtual void OnPointerEnter(PointerEventData pointerEventData)
    {
        // Logging.Log("Cursor Entering " + name + " GameObject");
        onEnter.Invoke(transform.position);
        onEnterIndex.Invoke(transform.position, index);
        isOver = true;
    }

    void FixedUpdate()
    {
        if(isOver)
        {
            onUpdate.Invoke();
        }
    }

    public virtual void OnPointerExit(PointerEventData pointerEventData)
    {
        //Logging.Log("Cursor Exiting " + name + " GameObject");
        onExit.Invoke();
        isOver = false;
    }
}
