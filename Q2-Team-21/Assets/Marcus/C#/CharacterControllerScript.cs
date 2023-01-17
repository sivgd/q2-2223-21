using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    /// <notes>
    /// Tags: GroundChecker, MainCamera
    /// layers: Ground, Interactables
    /// <notes>

    //Camera

    private GameObject PlayerCam;
    private Transform PlayerCamera;
    public float Sensitivity;
    private Vector2 Sensitivities;
    private Vector2 XYRotation;

    //Raycast

    private LayerMask InteractablesLayerMask;
    private GameObject LookingAtObj;

    //Utility
    public GameObject Boat;
    private GameObject BoatCam;
    public bool InBoat;
    public Transform PlayerBoatPosTransform;

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

    private Vector3 velocity;
    private bool isGrounded;

    //UI

    //////////////////////////////////////////////////////
    void Start()
    {
        //Camera

        Cursor.lockState = CursorLockMode.Locked;
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCamera = PlayerCam.transform;

        Sensitivities.x = Sensitivity;
        Sensitivities.y = Sensitivity;

        //Raycast

        InteractablesLayerMask = LayerMask.GetMask("Interactables");

        //Utility
        Boat = GameObject.FindGameObjectWithTag("PlayerBoat");
        Boat.GetComponent<BoatEngine>().enabled = false;
        BoatCam = GameObject.FindGameObjectWithTag("BoatCam");
        BoatCam.SetActive(false);

        //Movement

        controller = gameObject.GetComponent<CharacterController>();
        groundCheckOBJ = GameObject.FindGameObjectWithTag("GroundChecker");
        groundCheck = groundCheckOBJ.transform;
        speed = moveSpeed;
        speedButFaster = speed * 1.6f;

        //UI


    }

    private void FixedUpdate()
    {
        if (InBoat == true)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("PlayerBoatSpot").GetComponent<Transform>().position;
        }
    }

    //////////////////////////////////////////////////////
    void Update()
    {
        //Camera

        Vector2 MouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        XYRotation.x -= MouseInput.y * Sensitivities.y;
        XYRotation.y += MouseInput.x * Sensitivities.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);

        //Raycast

        if (InBoat == true && Input.GetKeyDown(KeyCode.E))
        {
            ExitBoat();
        }

        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, InteractablesLayerMask))
        {
            LookingAtObj = hit.transform.gameObject;
            if (LookingAtObj.tag == "PlayerBoat")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (InBoat == false)
                    {
                        EnterBoat();
                    }
                }
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

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, InteractablesLayerMask);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            EnterBoat();
        }
    }

    void EnterBoat()
    {
        Boat.GetComponent<BoatEngine>().enabled = true;
        PlayerCam.SetActive(false);
        BoatCam.SetActive(true);
        InBoat = true;
    }

    void ExitBoat()
    {
        Boat.GetComponent<BoatEngine>().enabled = false;
        BoatCam.SetActive(false);
        PlayerCam.SetActive(true);
        InBoat = false;
    }
}