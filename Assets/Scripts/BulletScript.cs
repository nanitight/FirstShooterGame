using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float life = 3;
    private void Awake()
    {
        Destroy(gameObject,life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("BoxSide")){
            //destroy anything but the constraints
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
