//by Homa.K
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputPointsController : BaseObject
{
    [System.Serializable]
    public enum TapStatus
    { 
        OFF,
        ON
    }
    public TapStatus tapStatus;
    public LineCreatorController linesController;
    private Vector3 startPoint;

    public override void init()
    {
        base.init();
    }


    public void OnOffset(InputAction.CallbackContext context)
    {
        if (tapStatus == TapStatus.ON)
        {
            Vector2 v = context.ReadValue<Vector2>();
            Vector3 mPos= Mouse.current.position.ReadValue();
            //konwertujemy do docelowej rozdziałki
            Vector2 converted=linesController.creatorSettings.convert(v);
            //Debug.Log("conveted magnitude:  " + converted.magnitude + " prog: " + linesController.creatorSettings.minMagnitudeForMove);
            //dajemy tylko punkty z jakimś sensownym offsetem
            if(converted.magnitude > linesController.creatorSettings.minMagnitudeForMove)
            {
                //dodajmy punkt   
                linesController.addNewPoint(mPos, linesController.creatorSettings.convert(mPos));
            }
        }
    }

    public void OnTap(InputAction.CallbackContext context)
    {
         if(context.phase == InputActionPhase.Performed)
        {
            tapStatus = TapStatus.ON;
            linesController.startRecord();
            startPoint = Mouse.current.position.ReadValue();

            //ustawiamy miejsce tapniecia jako pierwszy punkt   
             linesController.addNewPoint(startPoint, linesController.creatorSettings.convert(startPoint));
           
        }
         else if(context.phase == InputActionPhase.Canceled)
        {
            tapStatus = TapStatus.OFF;
            linesController.endRecord();
        }
    }

}
