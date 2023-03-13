using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    private float speed = 0.0f;
    public Text scoreUI;

    public Material[] availableMaterials ;

    public List<GameObject> activeTargetList = new List<GameObject>();

    public GameObject targetPrefab;

    public bool play = true;

    public float maxSpeed = 100, minSpeed = 5;

    public int killed = 0, startingMax = 3;

    bool RandomBool(int maxChance = 0, int minChance = -1)
    {
        return Random.Range(minChance,maxChance+1) >= 0; //max is Exclusive
    }
    private void CreateTarget()
    {
        List<Transform> xTransforms = new List<Transform>();
        List<Transform> yTransforms = new List<Transform>();
        List<Transform> zTransforms = new List<Transform>();

        var target = Instantiate(targetPrefab, transform.position, transform.rotation);
        target.GetComponent<TargetChild>().controller= this; //giving it the controller property

        speed = Random.Range(minSpeed, maxSpeed);
        target.GetComponent<TargetMovement>().movementSpeed = speed;
        target.GetComponent<TargetMovement>().constantMovement = RandomBool();
        int axisChosen = Random.Range(0, 4); // 0 = all axis, 1 = x-axis, 2 = y-axis , 3 = z-axis
        target.GetComponent<TargetMovement>().axisChosen = axisChosen;

        Transform[] allTransforms = FindAxisTargets();
        foreach (Transform obj in allTransforms)
        {
            if (obj.GetComponent<TargetBoundary>().OnlyXMovement())
            {
                xTransforms.Add(obj);
            }
            else if (obj.gameObject.GetComponent<TargetBoundary>().OnlyZMovement())
            {
                zTransforms.Add(obj);
                //yTransforms.Add(obj);
                //xTransforms.Add(obj);
            }
            else if (obj.gameObject.GetComponent<TargetBoundary>().OnlyYMovement())
            {
                yTransforms.Add(obj);
                //xTransforms.Add(obj);
            }
        }

        if (target.GetComponent<TargetMovement>()) { 
            target.GetComponent<TargetMovement>().xTargetLocation = xTransforms.ToArray();
            target.GetComponent<TargetMovement>().yTargetLocation = yTransforms.ToArray();
            target.GetComponent<TargetMovement>().zTargetLocation = zTransforms.ToArray(); 
        } 
        activeTargetList.Add(target);
    }

    private Transform[] FindAxisTargets()
    {
        //traverse children to find the axis targets

        TargetBoundary[] temp = gameObject.GetComponentsInChildren<TargetBoundary>();
        List<Transform> targets = new List<Transform>();
        foreach(var target in temp)
        {
            //Debug.Log("object " + target);
            targets.Add(target.gameObject.transform);
        }

        return targets.ToArray();
    }

    private void Update()
    {
        if (killed < startingMax && play )
        {

            if (activeTargetList.Count > startingMax )
            {
                play = false;
                //Debug.Log("Play is false, startmax: "+startingMax);
            }
            else
            {
                CreateTarget();
            }
        }
        else
        {
            if (killed >= startingMax)
            {
                play = true;
                startingMax += (killed/2);
            }
        }
    }

    private void CheckForKilled()
    {

    }

    public void RemoveMe(GameObject childToRemove)
    {
        killed++;
        int i = activeTargetList.FindIndex(x => x == childToRemove);
        if (i >=0 && i < activeTargetList.Count)
        { 
            activeTargetList.RemoveAt(i);
        }

        if (scoreUI != null)
        {
            if (scoreUI.text != null)
            {
                scoreUI.text = "Killed: "+killed.ToString();

            }
        }
    }

}
