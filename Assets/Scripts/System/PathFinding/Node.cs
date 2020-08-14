using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Node : IComparable
{
    public float nodeTotalCost;
    public float estimatedCost;
    public bool passable;
    public Node parent;
    public Vector3 position;
    public int column;
    public int row;
    public int constructionID;
    public Node()
    {
        this.estimatedCost = 0.0f;
        this.nodeTotalCost = 1.0f;
        this.constructionID = -1;
        this.passable =true;
        this.parent = null;
    }

    public Node(Vector3 pos)
    {
        this.estimatedCost = 0.0f;
        this.nodeTotalCost = 1.0f;
        this.passable = true;
        this.parent = null;
        this.position = pos;
        this.constructionID = -1;
    }

    public void markAsUnpassable()
    {
        this.passable = false;
    }


    public int CompareTo(object obj)
    {
        Node node = (Node)obj;
        //Negative value means object comes before this in the sort
        //order.
        if (this.estimatedCost < node.estimatedCost)
            return -1;
        //Positive value means object comes after this in the sort
        //order.
        if (this.estimatedCost > node.estimatedCost) return 1;
        return 0;
    }
}
