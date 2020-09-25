using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLineDrawer : BaseObject
{
    public LineRenderer lr;

    public void setPointsForLine(List<Vector3>points)
    {
        lr.useWorldSpace = true;
        lr.positionCount = points.Count;
        lr.SetPositions(points.ToArray());
    }

    public void showLines()
    {
        lr.enabled = true;
    }

    public void hideLines()
    {
        lr.enabled = false;
    }
}
