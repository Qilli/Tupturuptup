using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawerDebug : BaseObject
{
    [System.Serializable]
    public enum DebugDrawMode
    {
        CONSTANT,
        TIME
    }

    public DebugDrawMode drawMode = DebugDrawMode.TIME;
    public float currentShowTime = 3.0f;
    public List<Vector3> points = new List<Vector3>();
    public LineCreatorSettings lineSettings;

    private Vector3 start;
    private Vector3 end;

    public void clear()
    {
        points.Clear();
    }

    public void addPoint(Vector3 point)
    {
        point.z = 0;
        points.Add(point);
    }

    public override void init()
    {
        base.init();
        clear();
    }


    public void drawTimeLines(List<Line> lines)
    {
        drawMode = DebugDrawMode.TIME;
        for (int a = 0; a < lines.Count; ++a)
        {
            Debug.DrawLine(lines[a].start, lines[a].end,
                lineSettings.randomColor ? new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)) : lineSettings.lineColor,currentShowTime);
        }
    }

    public override void onFixedUpdate(float fixedDelta)
    {
        base.onFixedUpdate(fixedDelta);
        if (drawMode == DebugDrawMode.CONSTANT)
        {
            for (int a = 0; a < points.Count - 1; ++a)
            {
                start = points[a];
                end = points[a + 1];
                Debug.DrawLine(start, end,
                    lineSettings.randomColor ? new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)) : lineSettings.lineColor);
            }
        }
    }
}
