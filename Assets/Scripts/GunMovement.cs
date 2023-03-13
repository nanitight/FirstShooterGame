using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{

    private Vector3 gunDefaultLocatiion = new Vector3(0.5f, -1.2f, -8.7f);
    private Quaternion gunOriginalRotation = new Quaternion(0.705592811f, 0.0462469459f, -0.705592811f, -0.0462469459f);
    private float leftXLimit = -6, rightXLimit = 6, maxLeftRightDistance=0.05f;
    private float upYLimit = 3, downYLimit = -3; 
    public float rotationSpeed = 4f, leftRightSpeed = 8f; 
    private void Start()
    {
        transform.SetPositionAndRotation(gunDefaultLocatiion, gunOriginalRotation);
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        
        if (Input.GetKey(KeyCode.LeftArrow)){
            //increase x position until -6 and 6
            if(pos.x > leftXLimit && pos.x <rightXLimit)
            {
                pos.x -= leftRightSpeed * Time.deltaTime;
            }
            else
            {
                pos.x = leftXLimit + maxLeftRightDistance;
            }
            this.transform.position = Vector3.MoveTowards(transform.position, pos,maxLeftRightDistance);
        }
        
        if (Input.GetKey(KeyCode.RightArrow)) { 
            if(pos.x > leftXLimit && pos.x <rightXLimit)
            {
                pos.x += leftRightSpeed * Time.deltaTime;
            }
            else
            {
                pos.x = rightXLimit - maxLeftRightDistance;

            }
            this.transform.position = Vector3.MoveTowards(transform.position, pos, maxLeftRightDistance);
        }
        if (Input.GetKey(KeyCode.UpArrow)) { 
            if (pos.y > downYLimit && pos.y <upYLimit)
            {
                pos.y += leftRightSpeed* Time.deltaTime;
            }
            else
            {
                pos.y = upYLimit - maxLeftRightDistance;
            }
            this.transform.position = Vector3.MoveTowards(transform.position, pos, maxLeftRightDistance);

        }
        if (Input.GetKey(KeyCode.DownArrow)){
            if (pos.y > downYLimit && pos.y < upYLimit)
            {
                pos.y -= leftRightSpeed * Time.deltaTime;
            }
            else
            {
                pos.y = downYLimit + maxLeftRightDistance;
            }
            this.transform.position = Vector3.MoveTowards(transform.position, pos, maxLeftRightDistance);

        }
        //if(Input.GetKey(KeyCode.)
    }
}
