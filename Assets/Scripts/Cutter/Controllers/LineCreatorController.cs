//by Homa.K
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreatorController : BaseObject
{
    public Camera usedCamera;
    public LineDrawerDebug debugLineDrawer;
    public LineCreatorSettings creatorSettings;
    [HideInInspector]
    public List<Vector2> points = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> pointsConverted = new List<Vector2>();

    public override void init()
    {
        base.init();
    }

    public void addNewPoint(Vector2 point,Vector2 convertedPoint)
    {
        points.Add(point);
        pointsConverted.Add(convertedPoint);
        //Debug.Log("before conversion: "+point+"  point: " + usedCamera.ScreenToWorldPoint(new Vector3(point.x, point.y, usedCamera.nearClipPlane)));
        debugLineDrawer.addPoint(usedCamera.ScreenToWorldPoint(new Vector3(point.x,point.y, usedCamera.nearClipPlane)));
    }

    public void startRecord()
    {
        points.Clear();
        pointsConverted.Clear();
        debugLineDrawer.clear();
    }

    public void endRecord()
    {
        debugLineDrawer.clear();
    }
}
