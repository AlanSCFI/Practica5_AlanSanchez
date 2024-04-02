using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDelArma : MonoBehaviour
{
    public Transform shootSpawn;
    public bool shooting;
    public GameObject bulletPrefab;

    void Update()
    {
        shooting = Input.GetKeyDown(KeyCode.JoystickButton7);
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        
        if (shooting) 
        {
            InstantiateBullet();
        }
    }

    private void InstantiateBullet()
    {
        Instantiate(bulletPrefab, shootSpawn.position, shootSpawn.rotation);

    }
}
