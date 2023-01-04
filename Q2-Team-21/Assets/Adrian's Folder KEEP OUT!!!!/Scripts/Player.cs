using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    private float timer;
    public float speed;
    public float health = 10;
    private Rigidbody rb;
    public float rotationSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity =false;
    }

    // Update is called once per frame
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
        if (Input.GetKey(KeyCode.Q))
        {
            // Rotate the player to the left
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }
        // If the E key is pressed
        else if (Input.GetKey(KeyCode.E))
        {
            // Rotate the player to the right
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }
        if (health <= 0)
        {
            rb.useGravity = true;
            timer += Time.deltaTime;
            gameObject.GetComponent<CharacterController>().enabled = false;
            if (timer > time)
            {
                timer = 0;
                Destroy(gameObject);
            }
            
        }
    }
}
