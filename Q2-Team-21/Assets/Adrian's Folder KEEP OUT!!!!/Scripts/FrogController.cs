using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float tongueLength = 10.0f; // The length of the tongue
    public float tongueThickness = 0.2f; // The thickness of the tongue
    public int tongueSegments = 10; // The number of segments in the tongue
    public float tongueCooldown = 1.0f; // The time between tongue attacks
    public LayerMask tongueLayerMask; // The layer mask for the objects that the tongue can hit

    private LineRenderer lineRenderer; // The line renderer component for the tongue
    private float tongueTimer = 0.0f; // The timer for the tongue cooldown
    private Vector3[] tonguePositions; // The positions of the segments in the tongue
    private bool tongueAttacking = false; // Whether the tongue is currently attacking

    void Start()
    {
        // Get the line renderer component
        lineRenderer = GetComponent<LineRenderer>();

        // Enable the line renderer component
        lineRenderer.enabled = true;

        // Set the line renderer component to render in world space
        lineRenderer.useWorldSpace = true;

        // Set the line renderer component's sorting layer and order
        lineRenderer.sortingLayerName = "Default";
        lineRenderer.sortingOrder = 0;
        // Initialize the tongue positions
        tonguePositions = new Vector3[tongueSegments];
        for (int i = 0; i < tongueSegments; i++)
        {
            tonguePositions[i] = transform.position;
        }
    }

    void Update()
    {
        // Check if the tongue is attacking
        if (tongueAttacking)
        {
            // Update the tongue positions
            for (int i = 0; i < tongueSegments - 1; i++)
            {
                tonguePositions[i] = tonguePositions[i + 1];
            }

            // Check if the tongue has reached its maximum length
            if (Vector3.Distance(tonguePositions[tongueSegments - 1], transform.position) > tongueLength)
            {
                // End the tongue attack
                tongueAttacking = false;
                tongueTimer = tongueCooldown;
            }
            else
            {
                // Extend the tongue
                Vector3 tongueDirection = (tonguePositions[tongueSegments - 1] - transform.position).normalized;
                tonguePositions[tongueSegments - 1] += tongueDirection * Time.deltaTime;
            }
        }
        else
        {
            // Decrement the tongue timer
            tongueTimer -= Time.deltaTime;

            // Check if the tongue attack button is pressed
            if (Input.GetButtonDown("Fire1") && tongueTimer <= 0.0f)
            {
                // Start the tongue attack
                tongueAttacking = true;

                // Convert the mouse cursor position to a ray in world space
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Check if the ray hits any objects in the scene
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    // Set the starting position of the tongue to the hit point
                    tonguePositions[tongueSegments - 1] = hit.point;
                }
                else
                {
                    // Set the starting position of the tongue to the player position
                    tonguePositions[tongueSegments - 1] = transform.position;
                }
            }
        }
    }
}
