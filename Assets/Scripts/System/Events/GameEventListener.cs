using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEventParams response;

    private void OnDisable()
    {
        gameEvent.unregisterListener(this);
    }

    private void OnEnable()
    {
        gameEvent.registerListener(this);
    }

    public virtual void onEventRaised(EventParams eventParams)
    {
        response.Invoke(eventParams);
    }
}
