using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    /// <notes>
    /// Tags: WaterChecker, MainCamera
    /// layers: Water, Interactables
    /// <notes>

    //Movement

    private CharacterController controller;
    public float moveSpeed;
    private float speed = 10;
    private float gravity = -18;
    private bool isWatered;
    private Vector3 velocity;

    private GameObject WaterCheckOBJ;

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
        Vector3 rotate= transform.up * x * 0.5f;
        gameObject.transform.forward += move * Time.deltaTime;
        gameObject.transform.Rotate(rotate);

        //UI

    }
}