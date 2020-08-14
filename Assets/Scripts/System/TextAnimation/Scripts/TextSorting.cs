using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSorting : MonoBehaviour
{
    public int SortLayer = 0;
    public int SortingLayerID = 0;
    // Use this for initialization
    void Start()
    {
        SortingLayerID = SortingLayer.GetLayerValueFromName("Default");
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingOrder = SortLayer;
            renderer.sortingLayerID = SortingLayerID;
        }
    }

}
