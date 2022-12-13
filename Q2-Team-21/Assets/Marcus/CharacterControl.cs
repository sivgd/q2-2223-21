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

    private CharacterController controller;
    public float moveSpeed;
    private float speed = 10;
    public float gravity;
    public float jumpHeight;

    //UI

    //////////////////////////////////////////////////////
    void Start()
    {
        //Movement

        controller = gameObject.GetComponent<CharacterController>();

        //UI

    }

    //////////////////////////////////////////////////////
    void Update()
    {
        // Movement

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * z * speed;
        Vector3 rotate= transform.up * x;
        controller.Move(move * Time.deltaTime);
        gameObject.transform.Rotate(rotate);

        //UI

    }
}