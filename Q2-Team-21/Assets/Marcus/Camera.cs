using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject PlayerCam;
    private Transform PlayerCamera;
    public float Sensitivity;
    private Vector2 Sensitivities;
    private Vector2 XYRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCamera = PlayerCam.transform;

        Sensitivities.x = Sensitivity;
        Sensitivities.y = Sensitivity;
    }

    void Update()
    {
        Vector2 MouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        XYRotation.x -= MouseInput.y * Sensitivities.y;
        XYRotation.y += MouseInput.x * Sensitivities.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, 10f, 10f);
        XYRotation.y = Mathf.Clamp(XYRotation.y, -30f, 30f);

        PlayerCam.transform.eulerAngles = new Vector3(XYRotation.x, XYRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(XYRotation.x, XYRotation.y, 0f);
    }
}
