using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    // Speed of the frog
    public float speed = 10.0f;

    // Rotation speed of the frog
    public float rotationSpeed = 10.0f;

    // Mass of the frog
    public float mass = 1.0f;

    // Drag of the frog
    public float drag = 1.0f;

    // Angular drag of the frog
    public float angularDrag = 1.0f;

    // Force to apply to the frog when moving
    public Vector3 force = Vector3.zero;

    // Torque to apply to the frog when rotating
    public Vector3 torque = Vector3.zero;

    // Main camera
    Camera mainCamera;

    // Rigidbody of the frog
    Rigidbody rb;

    //void Start()
    //{
    //    // Get the main camera
    //    mainCamera = GameObject.Find("Camera").GetComponent<Camera>();

    //    // Get the rigidbody of the frog
    //    rb = GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    // Convert the mouse cursor position to a ray in world space
    //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

    //    // Check if the ray hits the ground
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        // Calculate the direction to the hit point
    //        Vector3 direction = hit.point - transform.position;
    //        direction.y = 0;

    //        // Rotate the frog towards the hit point
    //        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    //        // Calculate the force to apply to the frog
    //        force = transform.forward * speed;

    //        // Check if the frog has reached the hit point
    //        if (Vector3.Distance(transform.position, hit.point) < 0.1f)
    //        {
    //            // Set the force to zero
    //            force = Vector3.zero;

    //            // Play the landing sound
    //            AudioSource audio = GameObject.Find("Audio").GetComponent<AudioSource>();
    //            audio.Play();
    //        }
    //    }
    //}    //void Start()
    //{
    //    // Get the main camera
    //    mainCamera = GameObject.Find("Camera").GetComponent<Camera>();

    //    // Get the rigidbody of the frog
    //    rb = GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    // Convert the mouse cursor position to a ray in world space
    //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

    //    // Check if the ray hits the ground
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        // Calculate the direction to the hit point
    //        Vector3 direction = hit.point - transform.position;
    //        direction.y = 0;

    //        // Rotate the frog towards the hit point
    //        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    //        // Calculate the force to apply to the frog
    //        force = transform.forward * speed;

    //        // Check if the frog has reached the hit point
    //        if (Vector3.Distance(transform.position, hit.point) < 0.1f)
    //        {
    //            // Set the force to zero
    //            force = Vector3.zero;

    //            // Play the landing sound
    //            AudioSource audio = GameObject.Find("Audio").GetComponent<AudioSource>();
    //            audio.Play();
    //        }
    //    }
    //}

    void FixedUpdate()
    {
        // Apply the force to the frog
        rb.AddForce(force, ForceMode.Acceleration);

        // Set the mass and drag of the frog
        rb.mass = mass;
        rb.drag = drag;
        rb.angularDrag = angularDrag;
    }
}

