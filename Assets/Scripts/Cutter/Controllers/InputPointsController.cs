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
    private Vector2 currentStart;

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
            Vector2 converted=linesController.creatorSettings.convert(mPos);

            //dajemy tylko punkty z jakimś sensownym offsetem
            if(Vector2.Distance(converted,currentStart) > linesController.creatorSettings.minMagnitudeForMove)
            {
                //dodajmy punkt   
                linesController.addNewPoint(mPos, converted);
                currentStart = converted;
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
            currentStart = linesController.creatorSettings.convert(startPoint);
            //ustawiamy miejsce tapniecia jako pierwszy punkt   
            linesController.debugLineDrawer.drawMode = LineDrawerDebug.DebugDrawMode.CONSTANT;
             linesController.addNewPoint(startPoint, linesController.creatorSettings.convert(startPoint));
           
        }
         else if(context.phase == InputActionPhase.Canceled)
        {
            tapStatus = TapStatus.OFF;
            linesController.endRecord();
        }
    }

}
