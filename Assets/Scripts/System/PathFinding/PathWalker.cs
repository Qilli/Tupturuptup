using System.Collections.Generic;
using UnityEngine;

public class PathWalker
{
    public enum MoveDirection
    {
        NONE,
        LEFT,
        RIGHT,
        UP,
        DOWN,
        RIGHT_UP,
        LEFT_UP,
        RIGHT_DOWN,
        LEFT_DOWN
    }


    public List<Vector2> path = null;
    public float moveSpeed = 1.0f;
    public int currentTarget = 1;
    public Vector2 currentPosition;
    public bool isOnLadder;

    public bool IsWalking { get; set; }
    public bool IsBlocked { get; set; }
    public bool fragmentReached = false;
    public bool listenForAFragmentReach = false;

    private MoveDirection currentMoveDirection = MoveDirection.NONE;

    public void onFragmentReached()
    {
        fragmentReached = true;
    }


    public void setListenForAFragmentReached()
    {
        if (listenForAFragmentReach == false)
        {
            listenForAFragmentReach = true;
            fragmentReached = false;
        }
    }

    public void resetListenForAFragmentReached()
    {
        listenForAFragmentReach = false;
    }


    public virtual void initWalker()
    {
        currentTarget = 1;
        currentPosition = path[0];
        IsWalking = true;
     //   checkForLadder();
        IsBlocked = false;
        Logging.Log("walk");

    }

    public bool targetReached()
    {
        return currentPosition == path[path.Count - 1];
    }


    public Vector2 getCurrentMapPosition()
    {
      //  Logging.Log("TARGET POSITION: "+path[Mathf.Clamp(currentTarget, 0, path.Count - 1)]);
        return path[Mathf.Clamp(currentTarget, 0, path.Count - 1)];
    }

    public void resetWalker()
    {
        IsWalking = false;
        IsBlocked = false;
    }

    public MoveDirection getCurrentMoveDirection()
    {
        return currentMoveDirection;
    }


    void computeDirection(Vector2 offset)
    {
        //first check if move is in one direction
        if (offset.x == 0 && offset.y == 0)
        {
            //no move at all
            currentMoveDirection = MoveDirection.NONE;
        }
        else if (offset.x == 0)
        {
            //only move in y possible
            if (offset.y > 0)
            {
                //climb up
                currentMoveDirection = MoveDirection.UP;
            }
            else
            {
                //climb down
                currentMoveDirection = MoveDirection.DOWN;
            }
        }
        else if (offset.y == 0)
        {
            //left or right
            if (offset.x > 0)
            {
                //right
                currentMoveDirection = MoveDirection.RIGHT;
            }
            else
            {
                //left
                currentMoveDirection = MoveDirection.LEFT;
            }
        }
        else
        {
            //diagonal
            if (offset.x > 0)
            {
                if (offset.y > 0)
                {
                    //up right
                    currentMoveDirection = MoveDirection.RIGHT_UP;
                }
                else
                {
                    //down right
                    currentMoveDirection = MoveDirection.RIGHT_DOWN;
                }
            }
            else
            {
                if (offset.y < 0)
                {
                    //down left
                    currentMoveDirection = MoveDirection.LEFT_DOWN;
                }
                else
                {
                    //up left
                    currentMoveDirection = MoveDirection.LEFT_UP;
                }
            }
        }
    }

    public virtual Vector2 updateWalker(float delta)
    {
        if (currentTarget > path.Count - 1)
        {
            if (listenForAFragmentReach)
            {
                onFragmentReached();
            }
            return currentPosition;
        }

        //compute direction in which we are moving
        Vector2 offset = path[currentTarget] - currentPosition;
        computeDirection(offset);


        currentPosition = Vector2.MoveTowards(currentPosition, path[currentTarget], moveSpeed * delta);
        if (currentPosition==path[currentTarget] /*Mathf.Abs(currentPosition.x - path[currentTarget].x)<0.0001f && Mathf.Abs(currentPosition.y - path[currentTarget].y) < 0.0001f*/)
        {
            if (listenForAFragmentReach)
            {
                onFragmentReached();          
            }
            currentTarget++;

        }
        return currentPosition;
    }


}
