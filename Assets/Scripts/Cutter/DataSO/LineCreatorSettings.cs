using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Cutter/Settings/LineCreatorSettings")]
public class LineCreatorSettings : ScriptableObject
{
    public enum LineCreatorMode
    {
        WAIT_TILL_END,
        PER_LINE
    }
    [Header("Base")]
    [Tooltip("Elements")]
    public CutElement[] elements;
    [Tooltip("Docelowa rozdzielczosc w jakiej sprawdzamy linie")]
    public Vector2Int targetResolution= new Vector2Int(640,480);
    [Tooltip("Minimalna długośc ruchu żeby traktować go jako punkt(0-100%)")]
    public float minMagnitudeForMove=2;
    [Tooltip("Minimalna długośc linie dla jednego cięcia(0-100%)")]
    public float minLineSizeForCut=3;
    [Tooltip("Typ cięcia")]
    public LineCreatorMode mode = LineCreatorMode.WAIT_TILL_END;
    [Tooltip("offset od hor/ver ktory wciaz trzyma tam sam kierunek")]
    public float maxAngleOffset = 12.5f;
    [Tooltip("max offset kąta przy juz wybranym kierunku")]
    public float maxAngleSmoothOffset = 30.0f;
    [Tooltip("grubość cięcią owoców")]
    public float cutWidth = 0.1f;
    [Header("Debug Draw")]
    public bool randomColor = false;
    public Color lineColor = Color.red;

    public CutElement getRandomElement()
    {
        return elements[Random.Range(0, elements.Length)];
    }

    public Vector2 convert(Vector2 offset)
    {
        int w = Screen.width;
        int h = Screen.height;
        Vector2 result = new Vector2();
        result.x = offset.x * ( ((float)targetResolution.x)/w);
        result.y = offset.y * (((float)targetResolution.y)/h);
        return result;
    }
}
