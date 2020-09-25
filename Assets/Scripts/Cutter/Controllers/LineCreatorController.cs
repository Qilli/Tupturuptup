//by Homa.K
using System.Collections.Generic;
using UnityEngine;

public class LineCreatorController : BaseObject
{
    public Camera usedCamera;
    public LineDrawerDebug debugLineDrawer;
    public CutLineDrawer lineDrawer;
    public LineCreatorSettings creatorSettings;
    [HideInInspector]
    public List<Vector2> points = new List<Vector2>();
    [HideInInspector]
    public List<Vector2> pointsConverted = new List<Vector2>();
    [HideInInspector]
    public List<Line> lines = new List<Line>();

    private List<Vector3> linePoints = new List<Vector3>();

    public override void init()
    {
        base.init();
    }

    public void addNewPoint(Vector2 point, Vector2 convertedPoint)
    {
        Vector3 world = usedCamera.ScreenToWorldPoint(new Vector3(point.x, point.y, usedCamera.nearClipPlane));
        points.Add(point);

        pointsConverted.Add(convertedPoint);

        //Debug.Log("before conversion: "+point+"  point: " + usedCamera.ScreenToWorldPoint(new Vector3(point.x, point.y, usedCamera.nearClipPlane)));
        debugLineDrawer.addPoint(world);

        world.z = 0;
        linePoints.Add(world);
        lineDrawer.setPointsForLine(linePoints);
    }

    public void startRecord()
    {
        points.Clear();
        pointsConverted.Clear();
        debugLineDrawer.clear();
        lines.Clear();
        linePoints.Clear();
        lineDrawer.setPointsForLine(linePoints);
        lineDrawer.showLines();
        debugLineDrawer.drawMode = LineDrawerDebug.DebugDrawMode.CONSTANT;
    }

    public void endRecord()
    {
        debugLineDrawer.clear();
        lineDrawer.hideLines();
        if (creatorSettings.mode == LineCreatorSettings.LineCreatorMode.WAIT_TILL_END)
        {
            createLinesFromAll();
        }
    }

    private bool getDirectionSmoothedFor(Vector2 dir, Line.LineDirection currentDir)
    {
        Vector2 dirCompare = Vector2.zero;
       // float angle = Vector2.SignedAngle(current, dir);
       if(currentDir == Line.LineDirection.HOR_RIGHT)
        {
            dirCompare.x = 1.0f;
        }
       else if(currentDir == Line.LineDirection.HOR_LEFT)
        {
            dirCompare.x = -1.0f;
        }
       else if(currentDir == Line.LineDirection.VER_UP)
        {
            dirCompare.y = 1.0f;
        }
       else if(currentDir == Line.LineDirection.VER_DOWN)
        {
            dirCompare.y = -1.0f;
        }
       else if(currentDir == Line.LineDirection.DIAG_RIGHT_UP)
        {
            dirCompare.x = 0.5f;
            dirCompare.y = 0.5f;
        }
       else if(currentDir == Line.LineDirection.DIAG_RIGHT_DOWN)
        {
            dirCompare.x = 0.5f;
            dirCompare.y = -0.5f;
        }
       else if(currentDir == Line.LineDirection.DIAG_LEFT_UP)
        {
            dirCompare.x = -0.5f;
            dirCompare.y = 0.5f;
        }
       else if(currentDir == Line.LineDirection.DIAG_LEFT_DOWN)
        {
            dirCompare.x = -0.5f;
            dirCompare.y = -0.5f;
        }
        float angle = Vector2.SignedAngle(dirCompare, dir);

        if(Mathf.Abs(angle)<creatorSettings.maxAngleSmoothOffset)
        {
            return true;
        }return false;
    }

    private Line.LineDirection getDirectionFor(Vector2 dir)
    {
        float angle = Vector2.SignedAngle(Vector2.up, dir);
        Debug.Log("angle is: " + angle);
        if (angle < creatorSettings.maxAngleOffset && angle > -creatorSettings.maxAngleOffset)
        {
            //ver up
            return Line.LineDirection.VER_UP;
        }
        else if (angle > 180 - creatorSettings.maxAngleOffset || angle < -180 + creatorSettings.maxAngleOffset)
        {
            //ver down
            return Line.LineDirection.VER_DOWN;
        }
        else if (angle > 90 - creatorSettings.maxAngleOffset && angle < 90 + creatorSettings.maxAngleOffset)
        {
            //hor left
            return Line.LineDirection.HOR_LEFT;
        }
        else if (angle < -90 + creatorSettings.maxAngleOffset && angle > -90 - creatorSettings.maxAngleOffset)
        {
            //hor right
            return Line.LineDirection.HOR_RIGHT;
        }
        else if (dir.x > 0 && dir.y > 0)
        {
            //diag up/right
            return Line.LineDirection.DIAG_RIGHT_UP;
        }
        else if (dir.x < 0 && dir.y < 0)
        {
            //diag down/left
            return Line.LineDirection.DIAG_LEFT_DOWN;
        }
        else if (dir.x < 0 && dir.y > 0)
        {
            //diag up/left
            return Line.LineDirection.DIAG_LEFT_UP;
        }
        else
        {
            //diag right/down
            return Line.LineDirection.DIAG_RIGHT_DOWN;
        }
    }

    private void createLinesFromAll()
    {
        /* Debug.Log("0.5 i 0.5 angle: " + Vector2.SignedAngle(Vector2.up, new Vector2(0.5f, 0.5f)));
         Debug.Log("0.5 i 0.0 angle: " + Vector2.SignedAngle(Vector2.up, new Vector2(0.5f, 0.0f)));
         Debug.Log("0.5 i -0.5 angle: " + Vector2.SignedAngle(Vector2.up, new Vector2(0.5f, -0.5f)));
         Debug.Log("0.0 i -0.5 angle: " + Vector2.SignedAngle(Vector2.up, new Vector2(0.0f, -0.5f)));
         Debug.Log("-0.5 i -0.5 angle: " + Vector2.SignedAngle(Vector2.up, new Vector2(-0.5f,-0.5f)));
         Debug.Log("-0.5 i 0.0 angle: " + Vector2.SignedAngle(Vector2.up, new Vector2(-0.5f, 0.0f)));
         Debug.Log("-0.5 i 0.5 angle: " + Vector2.SignedAngle(Vector2.up, new Vector2(-0.5f, 0.5f)));*/

        if (points.Count <= 1) return;
        //lecimy po wszystkich punktach
        Vector2 start = points[0];
        Vector2 end = points[1];
        Vector2 current = end;

        Line.LineDirection lineDirection = getDirectionFor(end - start);
        Debug.Log("Start Direction is: " + lineDirection);
        int stopAt =points.Count-1 ;
        for (int a = 2; a < points.Count; ++a)
        {
            current = points[a] - points[a-1];
            bool res=getDirectionSmoothedFor(current, lineDirection);
            if(!res)
            {
                //złamanie linii, tutaj przerywamy
                stopAt = a;
                break;
            }
        }


            Line l = new Line();
            l.start = usedCamera.ScreenToWorldPoint(points[0]);
            l.end = usedCamera.ScreenToWorldPoint(points[stopAt]);
            lines.Add(l);
        

        debugLineDrawer.drawMode = LineDrawerDebug.DebugDrawMode.TIME;
        debugLineDrawer.drawTimeLines(lines);
    }
}
