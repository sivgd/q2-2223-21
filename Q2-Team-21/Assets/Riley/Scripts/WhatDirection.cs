using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatDirection : MonoBehaviour
{
    public float DirectionFacing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DirectionFacing = transform.localRotation.eulerAngles.y;
        //Debug.Log(transform.rotation.eulerAngles.y);
    }
}
