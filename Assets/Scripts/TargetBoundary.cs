using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBoundary : MonoBehaviour
{
    public bool OnlyXMovement()
    {
        if (transform.position.y <=-1 && transform.position.z <= 0) 
        {
            return true;
        }
        // it has moved from the original position
        return false;

    }

    public bool OnlyYMovement()
    {
        // this implicitly means there is x and y movement
        if (transform.position.z > 0)
        {
            return false;
        }
        return true;
    }

    public bool OnlyZMovement()
    {
        //this means there is x,y and z movement. 
        //return !OnlyXMovement() && !OnlyYMovement();
       return transform.position.z > 0;
    }
}
