using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float drainRate;
    // The speed at which the object will rotate
    public float rotationSpeed;

    // The distance at which the object will stick to the player
    public float stickDistance;

    // A reference to the player's rigidbody
    private Rigidbody playerRigidbody;

    // A reference to the object's rigidbody
    private Rigidbody objectRigidbody;

    // A flag indicating whether the object is sticking to the player
    private bool isSticking = false;
    
    void Awake()
    {
        // Find the object with the tag "Player"
        GameObject player = GameObject.FindWithTag("Player");
        print(player);

        // Get the player's rigidbody component
        playerRigidbody = player.GetComponent<Rigidbody>();
        print(playerRigidbody);

        // Get the object's rigidbody component
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        // If the object is sticking to the player, don't do anything
        if (isSticking)
        {
            return;
        }
        // Print the value of drainRate
        Debug.Log(drainRate);

        // If the player's rigidbody exists
        if (playerRigidbody != null)
        {
            // Calculate the direction in which the object should move
            Vector3 direction = (playerRigidbody.position - objectRigidbody.position).normalized;

            // Calculate the velocity at which the object should move
            Vector3 velocity = direction * rotationSpeed;

            // Move the object towards the player
            objectRigidbody.MovePosition(objectRigidbody.position + velocity * Time.deltaTime);

            // Calculate the distance between the object and the target
            float distance = Vector3.Distance(transform.position, playerRigidbody.position);


            // If the distance is less than the stick distance
            if (distance < stickDistance)
            {
                // Stick to the player
                objectRigidbody.velocity = Vector3.zero;
                objectRigidbody.angularVelocity = Vector3.zero;
                objectRigidbody.useGravity = false;
                transform.parent = playerRigidbody.transform;
            }
            else
            {
                // Rotate the object towards the target
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRigidbody.position - transform.position), rotationSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // If the object collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            objectRigidbody.isKinematic= true;
            // Set the flag indicating that the object is sticking to the player
            isSticking = true;

            // Stick to the player
            objectRigidbody.useGravity = false;
            transform.parent = playerRigidbody.transform;
            // Start the health drain coroutine
            StartCoroutine(DrainHealth());
            // Disable the box collider component
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator DrainHealth()
    {
        // Get the Player script component of the player
        Player playerScript = playerRigidbody.GetComponent<Player>();

        // While the object is sticking to the player
        while (isSticking)
        {
            // Drain the player's health
            playerScript.health -= drainRate * Time.deltaTime;

            yield return new WaitForSeconds(1.0f);
        }

        yield return null;
    }
}
