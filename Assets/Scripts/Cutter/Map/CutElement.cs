using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CutAssets/GameplayData/CutElement")]
public class CutElement : ScriptableObject
{
    [System.Serializable]
    public enum ElementType
    {
        DEFAULT,
        EMPTY,
        TOMATO_RED,
        TOMATO_BLUE
    }
    [Tooltip("Rodzaj elementu/owocu/warzywa itp")]
    public ElementType typeElem;
    [Tooltip("Bazowa statyczna grafika")]
    public Sprite baseStaticVisual;
    [Header("Prefabs dla cięć")]
    [Tooltip("Animacje cięcia dla różnych kierunków")]
    public GameObject prefabCut_HorizontalRight;
    public GameObject prefabCut_HorizontalLeft;
    public GameObject prefabCut_VerticalUp;
    public GameObject prefabCut_VerticalDown;
    public GameObject prefabCut_DiagLeftUp;
    public GameObject prefabCut_DiagLeftDown;
    public GameObject prefabCut_DiagRightUp;
    public GameObject prefabCut_DiagRightDown;

    public GameObject getCutPrefabForCut(Line.LineDirection direction)
    {
        switch(direction)
        {
            case Line.LineDirection.DIAG_LEFT_DOWN:return prefabCut_DiagLeftDown;
            case Line.LineDirection.DIAG_LEFT_UP:return prefabCut_DiagLeftUp;
            case Line.LineDirection.DIAG_RIGHT_DOWN:return prefabCut_DiagRightDown;
            case Line.LineDirection.DIAG_RIGHT_UP:return prefabCut_DiagRightUp;
            case Line.LineDirection.HOR_LEFT:return prefabCut_HorizontalLeft;
            case Line.LineDirection.HOR_RIGHT:return prefabCut_HorizontalRight;
            case Line.LineDirection.VER_DOWN:return prefabCut_VerticalDown;
            case Line.LineDirection.VER_UP: return prefabCut_VerticalUp;
            default:return prefabCut_HorizontalRight;
        }
    }
}
