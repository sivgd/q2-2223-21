using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Camera
    private GameObject PlayerCam;
    private Transform PlayerCamera;
    public float Sensitivity;
    private Vector2 Sensitivities;
    private Vector2 XYRotation;
    private GameObject boat;

    //Raycast

    private LayerMask InteractablesLayerMask;
    private GameObject LookingAtObj;

    void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Player");
        //Camera

        Cursor.lockState = CursorLockMode.Locked;
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCamera = gameObject.transform;

        Sensitivities.x = Sensitivity;
        Sensitivities.y = Sensitivity;

        //Raycast

        InteractablesLayerMask = LayerMask.GetMask("Interactables");
    }

    void Update()
    {
        gameObject.transform.position = boat.transform.position;
        //Camera

        Vector2 MouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        XYRotation.x -= MouseInput.y * Sensitivities.y;
        XYRotation.y += MouseInput.x * Sensitivities.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, 10f, 10f);
        //XYRotation.y = Mathf.Clamp(XYRotation.y, -30f, 30f);

        PlayerCam.transform.eulerAngles = new Vector3(XYRotation.x, XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, XYRotation.y, 0f);

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
    }
}
