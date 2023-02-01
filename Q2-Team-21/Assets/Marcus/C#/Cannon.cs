using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Cannon : MonoBehaviour
{
    public GameObject Cannonball;
    public Transform barrel;
    public GameObject Boat;

    public float force;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(Cannonball, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = barrel.forward * force * Time.deltaTime;
        }
    }
}
