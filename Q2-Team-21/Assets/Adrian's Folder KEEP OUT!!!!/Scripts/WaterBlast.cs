using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlast : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Car");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * speed;

        if(player.GetComponent<Player>().health == 0 || GameObject.FindGameObjectsWithTag("Car") == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Car")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Player>().health--;
            Destroy(gameObject);
        }
    }
}
