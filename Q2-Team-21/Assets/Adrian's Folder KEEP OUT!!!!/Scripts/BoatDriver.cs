using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDriver : MonoBehaviour
{
    //// Speed of the boat
    //public float speed = 10.0f;

    //// Rotation speed of the boat
    //public float rotationSpeed = 10.0f;

    //// Mass of the boat
    //public float mass = 1.0f;

    //// Drag of the boat
    //public float drag = 1.0f;

    //// Angular drag of the boat
    //public float angularDrag = 1.0f;

    //// Force to apply to the boat when moving
    //public Vector3 force = Vector3.zero;

    //// Torque to apply to the boat when rotating
    //public Vector3 torque = Vector3.zero;

    //// Wave generator script
    //public WaveHeight waveGenerator;

    //// Rigidbody of the boat
    //Rigidbody rb;

    //void Start()
    //{
    //    // Get the rigidbody of the boat
    //    rb = GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    // Get the horizontal input
    //    float horizontalInput = Input.GetAxis("Horizontal");

    //    // Get the vertical input
    //    float verticalInput = Input.GetAxis("Vertical");

    //    // Calculate the force to apply to the boat
    //    force = transform.forward * verticalInput * speed;

    //    // Calculate the torque to apply to the boat
    //    torque = transform.up * horizontalInput * rotationSpeed;

    //    // Calculate the slope of the wave surface at the boat's position
    //    Vector3 waveNormal = waveGenerator.GetWaveNormal(transform.position);
    //    float waveSlope = Vector3.Angle(waveNormal, Vector3.up);

    //    // Rotate the boat to match the slope of the wave surface
    //    Quaternion targetRotation = Quaternion.FromToRotation(transform.up, waveNormal);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.

}

