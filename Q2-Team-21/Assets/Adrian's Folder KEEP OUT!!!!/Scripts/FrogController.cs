using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float tongueExtendTime = 1.0f; // the amount of time it takes for the tongue to extend
    public float tongueRetractTime = 1.0f; // the amount of time it takes for the tongue to retract
    public float maxTongueLength = 10.0f; // the maximum length the tongue can reach
    public LineRenderer tongueRenderer; // the line renderer component for the tongue

    private Vector3 currentTongueEndPos; // the current endpoint of the tongue
    private float tongueTimer; // a timer for the tongue extend/retract animation
    private bool isTongueExtending = false; // a flag for whether the tongue is currently extending
    private bool isTongueRetracting = false;
    private int InteractablesLayerMask = 64;
    public GameObject endPoint;
    
void Update()
    {
        Vector3 dir = endPoint.transform.position - this.transform.position;
       
        if (Input.GetKeyDown(KeyCode.Space)) // if the player presses space
        {
            Vector3 pos = endPoint.transform.position;
            Debug.Log("current pos: " + pos);
            // create a ray from the camera in the direction the camera is facing
            Ray ray = new Ray(gameObject.transform.position, dir);
            RaycastHit hit;
            
            InteractablesLayerMask = LayerMask.GetMask("Enemy"); // this sets the layer mask to only hit objects on layer 8
            float maxDis = Vector3.Distance(gameObject.transform.position, pos);

            if (Physics.Raycast(ray, out hit, maxDis,InteractablesLayerMask, QueryTriggerInteraction.Ignore))
            {
                Debug.Log(hit.collider.gameObject.layer + " LayerNumber");
                Debug.Log(hit.collider.isTrigger + " HasTrigger");
                List<GameObject> hitObjects = new List<GameObject>();
                // create a ray from the camera in the direction the camera is facing
                //var ray = new Ray(origin: gameObject.transform.position, direction: endPoint.transform.forward);
                //RaycastHit hit;

                while (Physics.Raycast(ray, out hit))
                {
                    hitObjects.Add(hit.collider.gameObject);
                    ray = new Ray(hit.point + gameObject.transform.position * 0.01f, dir);
                }
                    
                              // if the distance between the start and end points exceeds the max length
                
                for (int i = 0; i < hitObjects.Count; i++)
                {
                    //Debug.Log(hitObjects[i].name);
                    if (hitObjects[i].tag == "Wave1" || hitObjects[i].tag == "Wave2")
                    {
                        hitObjects[i].GetComponent<MoveTowardsPlayer>().health--;
                    }
                }
                    

            }

            currentTongueEndPos = endPoint.transform.position; // set the endpoint to the point where the ray hit
            currentTongueEndPos.y = transform.position.y; // set the y position of the currentTongueEndPos to be the same as the player's y position

            if (Vector3.Distance(transform.position, currentTongueEndPos) > maxTongueLength)
            {
                Vector3 direction = (currentTongueEndPos - transform.position).normalized;
                currentTongueEndPos = transform.position + direction * maxTongueLength;
            }
            isTongueExtending = true;
            tongueTimer = 0.0f;
        }
           
        
        if (isTongueExtending) // if the tongue is currently extending
        {
            tongueTimer += Time.deltaTime; // update the timer
            float t = tongueTimer / tongueExtendTime; // calculate the animation progress (0-1)

            // set the position of the first and second vertex of the line renderer
            tongueRenderer.SetPosition(0, transform.position);
            tongueRenderer.SetPosition(1, Vector3.Lerp(transform.position, currentTongueEndPos, t));

            if (tongueTimer >= tongueExtendTime) // if the timer has reached the extend time
            {
                isTongueExtending = false; // set the flag to indicate the tongue is no longer extending
                isTongueRetracting = true;
                tongueTimer = 0.0f;
            }
        }
        else if (isTongueRetracting) // if the tongue is currently retracting
        {
            tongueTimer += Time.deltaTime; // update the timer
            float t = tongueTimer / tongueRetractTime; // calculate the animation progress (0-1)

            // set the position of the first and second vertex of the line renderer
            tongueRenderer.SetPosition(0, transform.position);
            tongueRenderer.SetPosition(1, Vector3.Lerp(currentTongueEndPos, transform.position, t));

                if (tongueTimer >= tongueRetractTime) // if the timer has reached the retract time
            {
                isTongueRetracting = false;
                tongueRenderer.SetPosition(0, Vector3.zero);
                tongueRenderer.SetPosition(1, Vector3.zero);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Gizmos.DrawRay(gameObject.transform.position, endPoint.transform.position);
    }
}



