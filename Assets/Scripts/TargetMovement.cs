using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Transform[] xTargetLocation, yTargetLocation, zTargetLocation;
    public List<Transform> followLocations ;
    public bool constantMovement = false;
    public float movementSpeed = 10f;
    public int axisChosen = 0;
    private bool xMovement = false, yMovement = false;//, zMovement =false  ;
    private int followIndex;
    private float minDistance = 0.5f;
    private void Start(){
    /*
        Check if xtargetlocation is valid , any difficulty level needs the x at least ,
        Check also the y , if present then it is a target of v2( with x & y axis movement)
        if by chance the there is z, then v3(with x,y & z axis movement) 
    
    */
        if (xTargetLocation.Length>0){
            xMovement = true;
            if (axisChosen == 0 || axisChosen ==1)
            {
                followLocations.AddRange(xTargetLocation);
            }
        }
        else{
            Debug.Log("There are no x points to follow") ;
        }

        if (yTargetLocation.Length>0 && !xMovement){
            Debug.Log("There is no x movement points, but y. Cannot have y without x.") ;
        }
        else if(yTargetLocation.Length > 0){
            yMovement = true;
            if (axisChosen == 0 || axisChosen == 2)
            {
                followLocations.AddRange(yTargetLocation);
            }
        }

        if (zTargetLocation.Length>0 && ( !xMovement || !yMovement)){
            Debug.Log("There is no x movement points or y, but z. Cannot have z without x & y.") ;
        }
        else if (zTargetLocation.Length > 0 && (xMovement && yMovement) ){
            //zMovement = true ;
            if (axisChosen == 0 || axisChosen == 3)
            {
                followLocations.AddRange(zTargetLocation);
            }
        }

        //initialize indexes
        followIndex = 0;
    }
   

    private void Update()
    {
        if (xMovement)
        {
            followIndex = MoveInAxisOfChoice(followLocations, followIndex, constantMovement);
        }
    }
    private int MoveInAxisOfChoice(List<Transform> axisTarget, int index, bool constantMode)
    {
        int ind = index;

        //checking if we need to change xTarget location before moving
        if (Vector3.Distance(transform.position, axisTarget[ind].position) <= minDistance)
        {
            if (ind >= axisTarget.Count - 1)
            {
                ind = 0;
            }
            else
            {
                ind++;
            }
            //Debug.Log("Changing Lanes: "+ind);
        }
        //Debug.Log("Moving");
        if (constantMode)
        {
            transform.position = Vector3.MoveTowards(transform.position, axisTarget[ind].position, Time.deltaTime * minDistance * movementSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, axisTarget[ind].position, Time.deltaTime * minDistance * movementSpeed);
        }

        return ind;
    }

    private float CheckAxisDistance(Transform target, char axis)
    {
        float dist = float.PositiveInfinity;

        if (char.ToLower(axis) == 'x') { 
            dist = transform.position.x - target.position.x;
        }

        if (char.ToLower(axis) == 'y')
        {
            dist = transform.position.y - target.position.y;
        }

        if (char.ToLower(axis) == 'z')
        {
            dist = transform.position.z- target.position.z;
        }

        Debug.Log("Target: " + target.position.ToString() + " block: " + transform.position+ " axis: "+axis);

        //check if the difference is negative and make it positive
        if (dist < 0)
        {
            dist *= -1;
        }
        return dist;
    }
    
}

/* private void Update(){
        if (xMovement){
            //checking if we need to change xTarget location before moving
            xIndex = MoveInAxisOfChoice(xTargetLocation, xIndex, constantMovement,'x');
            Debug.Log("x : " + xIndex);
            // there is 1 dimensoinal movement in the script. 

            if (yMovement)
            {
                // there is 2 dimensional movement
                yIndex = MoveInAxisOfChoice(yTargetLocation, yIndex, constantMovement, 'y');
                Debug.Log("y : " + yIndex);

                //there is 3 dimensional movement
                if (zMovement)
                {
                    zIndex = MoveInAxisOfChoice(zTargetLocation, zIndex, constantMovement, 'z');
                }
            }
        }
    }

    private int MoveInAxisOfChoice(Transform[] axisTarget, int index, bool constantMode, char axisChosen)
    {
        int ind = index;

        //checking if we need to change xTarget location before moving
        if (Vector3.Distance(transform.position, axisTarget[ind].position) <= minDistance || CheckAxisDistance(axisTarget[ind],axisChosen)<= minDistance)
        {
            if (ind >= axisTarget.Length-1) { 
                ind = 0; 
            } else { 
                ind++; 
            }
            //Debug.Log("Changing Lanes: "+ind);
        }
        //Debug.Log("Moving");
        if (constantMode)
        {
            transform.position = Vector3.MoveTowards(transform.position, axisTarget[ind].position, Time.deltaTime * minDistance *movementSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, axisTarget[ind].position, Time.deltaTime*minDistance*movementSpeed);
        }
        return ind;
    } */