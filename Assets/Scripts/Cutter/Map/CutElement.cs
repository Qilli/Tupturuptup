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
    [Tooltip("Animacje cięcia dla różnych kierunków")]
    public GameObject prefabCut;

    public GameObject getCutPrefabForCut(Line.LineDirection direction)
    {
        Debug.Log("Get Prefab cut for: " + direction);
        return prefabCut;
    }
}
