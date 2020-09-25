using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line
{
    [System.Serializable]
    public enum LineDirection
    {
        HOR_RIGHT,
        HOR_LEFT,
        VER_UP,
        VER_DOWN,
        DIAG_RIGHT_UP,
        DIAG_LEFT_DOWN,
        DIAG_LEFT_UP,
        DIAG_RIGHT_DOWN
    }
    public Vector2 start;
    public Vector2 end;
    public LineDirection direction;
}
