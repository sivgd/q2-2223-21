using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    /// <notes>
    /// Tags: GroundChecker, MainCamera
    /// layers: Ground, Interactables
    /// <notes>

    //Movement

    Vector3 move;
    private float moveX;
    private float moveY;

    private CharacterController controller;
    public float moveSpeed;
    private float speed;
    public float gravity;
    public float jumpHeight;

    private GameObject WaterCheckOBJ;
    private Transform WaterCheck;
    private float WaterDistance = 0.3f;
    private LayerMask WaterLayerMask;

    private Vector3 velocity;
    private bool isGrounded;

    //UI

    //////////////////////////////////////////////////////
    void Start()
    {
        //Movement

        controller = gameObject.GetComponent<CharacterController>();
        WaterLayerMask = LayerMask.GetMask("Water");
        WaterCheckOBJ = GameObject.FindGameObjectWithTag("WaterChecker");
        WaterCheck = WaterCheckOBJ.transform;

        //UI

    }

    //////////////////////////////////////////////////////
    void Update()
    {
        // Movement

        isGrounded = Physics.CheckSphere(WaterCheck.position, WaterDistance, WaterLayerMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (isGrounded == true)
        {
            move = transform.right * x + transform.forward * z;
        }

        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //UI

    }
}