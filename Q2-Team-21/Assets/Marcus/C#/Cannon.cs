using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Cannon : MonoBehaviour
{
    public GameObject Cannonball;
    public Transform barrel;
    public GameObject Boat;
    private bool Reloaded;

    public float force;

    void Start()
    {
        
    }

    void Update()
    {
        if (Reloaded = true && Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(Cannonball, barrel.position, barrel.rotation);
            bullet.GetComponent<Rigidbody>().velocity = barrel.forward * force * Time.deltaTime;
            Reloaded = false;
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        Reloaded = true;
    }
}
