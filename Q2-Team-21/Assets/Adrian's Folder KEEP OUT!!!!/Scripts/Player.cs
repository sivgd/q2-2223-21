using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    private float timer;
    public float speed;
    public float health = 10;
    private Rigidbody rb;
    public float rotationSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity =false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health <= 0)
        {
            
            gameObject.GetComponent<BoatEngine>().enabled = false;
            if (timer > time)
            {
                timer = 0;
                Destroy(gameObject);
            }
            
        }
    }
}
