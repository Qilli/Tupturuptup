using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "AI/PathFinders/AStarSystem")]
public class AStarSystem : ScriptableObject
{
    public Node[,] nodes { get; set; }
    private PriorityQueue openList = new PriorityQueue();
    private HashSet<Node> closedList = new HashSet<Node>();
    private ArrayList neighbours = new ArrayList();
    private List<Node> toReset = new List<Node>();

    public void updateNodeMap()
    {
      /*  for (int i = 0; i < usedMap.map.columnsCount; i++)
        {
            for (int j = 0; j < usedMap.map.rowsCount; j++)
            {
                bool res = isTilePassable(i, j);
                if (!res)
                {
                    nodes[i, j].markAsUnpassable();
                }
                else
                {
                    nodes[i, j].passable = true;
                }
            }
        }*/
    }

    public void initSystem()
    {
    /*    if (mainMap == false) usedMap = testMap;
        else usedMap = normalMap;
        nodes = new Node[usedMap.map.columnsCount, usedMap.map.rowsCount];
        for (int i = 0; i < usedMap.map.columnsCount; i++)
        {
            for (int j = 0; j < usedMap.map.rowsCount; j++)
            {
                Vector3 cellPos = new Vector3(i , j , 0);
                Node node = new Node(cellPos);
                node.row = j;
                node.column = i;
                nodes[i, j] = node;

                bool res = isTilePassable(i, j);
                if (!res)
                {
                    nodes[i, j].markAsUnpassable();
                }
            }
        }*/
    }

    public virtual void resetParents()
    {
        foreach(Node n in toReset)
        {
            n.parent = null;
        }
        toReset.Clear();
    }

    public void GetNeighbours(Node node, ArrayList neighbors)
    {

        int row = node.row;
        int column = node.column;
        
        //Bottom
        AssignNeighbour(column, row-1, neighbors);
        //Top
        AssignNeighbour(column, row+1, neighbors);
        //Right
        AssignNeighbour(column+1, row, neighbors);
        //Left
        AssignNeighbour(column-1 ,row, neighbors);
        //bottom right
        AssignNeighbour(column+1, row - 1, neighbors);
        //bottom left
        AssignNeighbour(column - 1, row - 1, neighbors);
        //top left
        AssignNeighbour(column - 1, row+1, neighbors);
        //top right
        AssignNeighbour(column + 1, row+1, neighbors);
    }


    void AssignNeighbour(int column, int row, ArrayList neighbors)
    {
      /*  if (row != -1 && column != -1 &&
        row < usedMap.map.rowsCount && column < usedMap.map.columnsCount)
        {
            Node nodeToAdd = nodes[column, row];
            if (nodeToAdd.passable)
            {
                neighbors.Add(nodeToAdd);
            }
        }*/
    }



    public virtual bool isTilePassable(int x, int y)
    {
        /*   GroundCellHolder ground = usedMap.map.grid[x * usedMap.map.columnsCount + y];
           foreach (GroundType types in passableGrounds)
           {
               if (types == ground.groundType && ground.isPassable() == true)
               {
                   //no obstacle
                   return true;
               }
           }
           return false;*/
        return false;
    }

    public int GetRow(int index)
    {
        int row = 0;// index / usedMap.map.columnsCount;
        return row;
    }
    public int GetColumn(int index)
    {
        int col = 0;// index % usedMap.map.columnsCount;
        return col;
    }

    private float heuristicEstimateCost(Node curNode, Node goalNode)
    {
        Vector3 vecCost = curNode.position - goalNode.position;
        if(vecCost.x!=0 && vecCost.y!=0)
        {
            return vecCost.magnitude * 2.0f;
        }
        else return vecCost.magnitude;
    }

    public List<Vector2> findPath(Vector2 posStart,Vector2 posEnd)
    {
        /*   resetParents();
           int x1 = (int)posStart.x;
           int y1 = (int)posStart.y;
           int x2 = (int)posEnd.x;
           int y2 = (int)posEnd.y;

           if(x1<0 || x2<0 || y1<0 || y2<0 || x1>= usedMap.map.columnsCount || 
               x2>= usedMap.map.columnsCount || y1>= usedMap.map.rowsCount || y2>= usedMap.map.rowsCount)
           {
               Logging.Log("AStarSystem: Wrong path start or end.", LogType.ERROR);
               return null;
           }

           Node start =nodes[x1,y1];
           Node end = nodes[x2, y2];
           return findPath(start, end);*/
        return null;
    }





    public List<Vector2> findPath(Node start, Node goal)
    {
        openList.ClearAll();
        openList.Push(start);
        start.nodeTotalCost = 0.0f;
        start.estimatedCost = heuristicEstimateCost(start, goal);
        closedList.Clear();
        Node node = null;

       
        while (openList.Length != 0)
        {
          
            node = openList.First();
            //Check if the current node is the target node
            if (node.position == goal.position)
            {
                return calculatePath(node);
            }
            //Create an ArrayList to store the neighboring nodes
            neighbours.Clear();
            
            GetNeighbours(node, neighbours);
            
            for (int i = 0; i < neighbours.Count; i++)
            {
                Node neighbourNode = (Node)neighbours[i];
                if (!closedList.Contains(neighbourNode))
                {
                    float cost = heuristicEstimateCost(node,
                    neighbourNode);
                    float totalCost = node.nodeTotalCost + cost;
                    float neighbourNodeEstCost = heuristicEstimateCost(
                    neighbourNode, goal);
                    neighbourNode.nodeTotalCost = totalCost;
                    neighbourNode.parent = node;
                    toReset.Add(neighbourNode);
                    neighbourNode.estimatedCost = totalCost +
                    neighbourNodeEstCost;
                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Push(neighbourNode);
                    }
                }
           
            }
            //Add the current node to the closed list
            closedList.Add(node);
            //and remove it from openList
            openList.Remove(node);


        }

        if (node.position != goal.position)
        {
            //resetujemy parents node'ow
            return null;
        }
        return calculatePath(node);


    }

    private List<Vector2> calculatePath(Node node)
    {
        List<Vector2> list = new List<Vector2>();
        while (node != null)
        {
            list.Add(node.position);
            node = node.parent;
        }
        list.Reverse();
        return list;
    }
}
