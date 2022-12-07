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
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCamera = PlayerCam.transform;

        Sensitivities.x = Sensitivity;
        Sensitivities.y = Sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
