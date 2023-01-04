using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // The speed at which the player moves
    public float speed;
    public float rotationSpeed;
    void Update()
    {
        // Get the horizontal and vertical input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Normalize the movement direction
        movement = movement.normalized;

        // Move the player
        transform.position += movement * speed * Time.deltaTime;

        // If the Q key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Rotate the player to the left
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }
        // If the E key is pressed
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // Rotate the player to the right
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }

    }
}
