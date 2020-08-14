using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class onClickElement : MonoBehaviour, IPointerClickHandler
{
    public EventVector2 onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick.Invoke(transform.position);

    }
}
