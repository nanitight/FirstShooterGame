using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollower : MonoBehaviour
{
    public GameObject playerToFollow;

    private Vector3 defaultCameraLocation = new Vector3(0, 1.5f, -11), offset; 
    // Start is called before the first frame update
    void Start()
    {
        transform.position = defaultCameraLocation;   
        offset = playerToFollow.transform.position-defaultCameraLocation;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 myPos = transform.position; 
        //transform.position = new Vector3(playerToFollow.transform.position.x - offset.x, myPos.y ,myPos.z);
    }
}
