using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform bulletSpawnLocation;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    //private Vector3 bulletSpawnDefaultLocatiion = new Vector3(-0.3f, -0.3f, -0.085f);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnLocation.up * bulletSpeed;
            
        }
    }
}
