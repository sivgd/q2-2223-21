using System.Collections;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public bool cannonBallCollected;
    private GameObject CannonBalls;

    //Camera

    private GameObject PlayerCam;
    private Transform PlayerCamera;
    [SerializeField] float Sensitivity;
    private Vector2 Sensitivities;
    private Vector2 XYRotation;

    //Movement

    Vector3 move;
    private CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] float gravity = -38;
    [SerializeField] float jumpHeight;
    [SerializeField] Transform groundCheck;
    private float groundDistance = 0.3f;
    private Vector3 velocity;
    public bool Dead;

    //UI

    [SerializeField] TransitionHandler Parent;
    [SerializeField] GameObject BoatTXT;
    [SerializeField] GameObject LightTXT;
    private bool InBoat;

    //////////////////////////////////////////////////////
    void Start()
    {
        //Camera
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCamera = PlayerCam.transform; 
        Sensitivities.x = Sensitivity;
        Sensitivities.y = Sensitivity;
        Cursor.lockState = CursorLockMode.Locked;

        //Movement
        controller = gameObject.GetComponent<CharacterController>();
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
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);

        //Raycast

        InBoat = Parent.InBoat;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Parent.ExitBoat();
        }

        var ray = new Ray(origin: PlayerCam.transform.position, direction: PlayerCam.transform.forward);
        RaycastHit hit;
        GameObject LookingAtObj;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            LookingAtObj = hit.transform.gameObject;
            if (LookingAtObj.tag == "PlayerBoat" && InBoat == false)
            {
                BoatTXT.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Parent.EnterBoat();
                }
            }
            else
            {
                BoatTXT.SetActive(false);
            }

            if (LookingAtObj.tag == "LightPost" && InBoat == false)
            {
                LightTXT.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LookingAtObj.GetComponent<LightPointScript>().active = true;
                }
            }
            else
            {
                LightTXT.SetActive(false);
            }
        }
        else
        {
            LookingAtObj = null;
        }

        //Movement

        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);

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

        //Jump

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Dead == true)
        {
            Parent.dead = true;
            Dead = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CannonBalls"))
        {
            cannonBallCollected = true;
            CannonBalls = collision.gameObject;
            CannonBalls.SetActive(false);
            StartCoroutine(ResetBoolFPS());
        }
    }

    IEnumerator ResetBoolFPS()
    {
        yield return new WaitForSeconds(0.5f);
        cannonBallCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            Dead = true;
        }
    }
}