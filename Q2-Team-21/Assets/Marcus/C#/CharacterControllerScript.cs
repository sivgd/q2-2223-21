using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
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

    private CharacterController controller;
    Vector3 move;
    private LayerMask GroundLayer;
    public float moveSpeed;
    private float speed;
    private float speedButFaster;
    private float stamina;
    private float gravity = -38;
    public float jumpHeight;

    private GameObject groundCheckOBJ;
    private Transform groundCheck;
    private float groundDistance = 0.3f;

    private Vector3 velocity;
    private bool isGrounded;

    //UI

    public GameObject BoatTXT;
    public GameObject LightTXT;

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
        BoatCam = GameObject.FindGameObjectWithTag("BoatCam");
        BoatCam.SetActive(false);
        Boat.GetComponent<BoatEngine>().enabled = false;

        //Movement

        GroundLayer = LayerMask.GetMask("Ground");
        controller = gameObject.GetComponent<CharacterController>();
        groundCheckOBJ = GameObject.FindGameObjectWithTag("GroundChecker");
        groundCheck = groundCheckOBJ.transform;
        speed = moveSpeed;
        speedButFaster = speed * 1.6f;
    }

    private void FixedUpdate()
    {
        //if (InBoat == true)
        //{
        //    gameObject.transform.position = GameObject.FindGameObjectWithTag("PlayerBoatSpot").GetComponent<Transform>().position;
        //}
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
            BoatTXT.SetActive(false);
        }
        else if(InBoat == false)
        {
            BoatTXT.SetActive(false);
        }
        else if (InBoat == true)
        {
            BoatTXT.SetActive(false);
        }

        var ray = new Ray(origin: PlayerCam.transform.position, direction: PlayerCam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            LookingAtObj = hit.transform.gameObject;
            if (LookingAtObj.tag == "PlayerBoat" && InBoat == false)
            {
                BoatTXT.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (InBoat == false)
                    {
                        EnterBoat();
                        BoatTXT.SetActive(false);
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

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundLayer);

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

        if (InBoat == true)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("PlayerBoatSpot").GetComponent<Transform>().position;
        }

        //UI
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Death();
        }
    }

    public void EnterBoat()
    {
        InBoat = true;
        Boat.GetComponent<BoatEngine>().enabled = true;
        BoatCam.SetActive(true);
        PlayerCam.SetActive(false);
    }

    public void ExitBoat()
    {
        InBoat = false;
        Boat.GetComponent<BoatEngine>().enabled = false;
        BoatCam.SetActive(false);
        PlayerCam.SetActive(true);
    }

    public void Death()
    {
        InBoat = true;
        ExitBoat();
    }
}