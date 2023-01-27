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
    private GameObject player;
    private Player healthss;
    // A reference to the object's rigidbody
    private Rigidbody objectRigidbody;
    
    // A flag indicating whether the object is sticking to the player
    private bool isSticking = false;

    public int health;

    public bool debug;

    [SerializeField]
    private float z;
    private float x;
    private float y;
    void Start()
    {
        // Find the object with the tag "Player"
        

        
    }

    void Update()
    {
        
        player = GameObject.FindWithTag("PlayerBoat");
        
        
        
        GameObject healths = GameObject.FindWithTag("Car");
        // Get the player's rigidbody component
        playerRigidbody = player.GetComponent<Rigidbody>();
        healthss = healths.GetComponent<Player>();

        // Get the object's rigidbody component
        objectRigidbody = GetComponent<Rigidbody>();
        //Debug.Log(objectRigidbody);
        if (health <= 0) Destroy(gameObject);
        // If the object is sticking to the player, don't do anything
        if (isSticking)
        {
            return;
        }
        

        // If the player's rigidbody exists
        if (playerRigidbody != null)
        {

            //Debug.Log("Rigidbody component is attached to the player object");
            // Calculate the direction in which the object should move
            Vector3 direction = (playerRigidbody.position - objectRigidbody.position).normalized;
            

            // Calculate the velocity at which the object should move
            Vector3 velocity = direction * rotationSpeed;

            // Move the object towards the player
            objectRigidbody.MovePosition(objectRigidbody.position + velocity * Time.deltaTime);
            x = objectRigidbody.position.x;
            y = player.transform.position.y;
            z = objectRigidbody.position.z;
            float ey = gameObject.transform.position.y;
            if (debug)
            {
                
                Debug.Log(direction);
                Debug.Log("player y: " + y);
                Debug.Log("enemy y pos: " + ey);
                Debug.Log("enemy z pos: " + z);
                Debug.Log("Enemy x pos: " + x);
            }
            if (player != null)
            {
                transform.position = new Vector3(x, y, z);


            }

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
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("PlayerBoat"))
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
            GetComponent<BoxCollider>().isTrigger= true;
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
            healthss.health -= drainRate * Time.deltaTime;

            yield return new WaitForSeconds(1.0f);
        }

        yield return null;
    }
}
