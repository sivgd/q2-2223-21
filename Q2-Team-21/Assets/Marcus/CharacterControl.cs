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

    //Raycast

    private LayerMask InteractablesLayerMask;
    private GameObject LookingAtObj;

    //Movement

    Vector3 move;
    private float moveX;
    private float moveY;

    private CharacterController controller;
    public float moveSpeed;
    private float speed;
    private float speedButFaster;
    private float stamina;
    private float gravity = -18;
    public float jumpHeight;

    private GameObject groundCheckOBJ;
    private Transform groundCheck;
    private float groundDistance = 0.3f;
    private LayerMask groundLayerMask;

    private Vector3 velocity;
    private bool isGrounded;

    //UI

    //////////////////////////////////////////////////////
    void Start()
    {
        //Raycast

        InteractablesLayerMask = LayerMask.GetMask("Interactables");

        //Movement

        controller = gameObject.GetComponent<CharacterController>();
        groundLayerMask = LayerMask.GetMask("Ground");
        groundCheckOBJ = GameObject.FindGameObjectWithTag("GroundChecker");
        groundCheck = groundCheckOBJ.transform;
        speed = moveSpeed;
        speedButFaster = speed * 1.6f;

        //UI


    }

    //////////////////////////////////////////////////////
    void Update()
    {
        //Raycast

        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, InteractablesLayerMask))
        {
            LookingAtObj = hit.transform.gameObject;
            if (LookingAtObj.tag == "")
            {

            }
            if (LookingAtObj.tag == "")
            {

            }
            if (LookingAtObj.tag == "")
            {

            }
        }
        else
        {
            LookingAtObj = null;
        }

        // Movement

        if (speed == speedButFaster)
        {
            stamina -= Time.deltaTime;
        }
        else if (stamina <= 5)
        {
            stamina += Time.deltaTime * 0.6f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || stamina <= 0)
        {
            speed = moveSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0)
        {
            speed = speedButFaster;
        }

        //^^^sprint end

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

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