using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillThisWork : MonoBehaviour
{
    public float DegreesRotate;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        DegreesRotate = 180;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(0, DegreesRotate, 0);
    }
}
