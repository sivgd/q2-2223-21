using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    // The starting position of the tongue
    public Transform startPosition;
    public float minY = -5.0f;
    // The ending position of the tongue
    public Vector3 endPosition;

    // The speed at which the tongue extends
    public float speed = 1.0f;

    public float offset = 1f;
    // The Line Renderer component used to render the tongue
    LineRenderer lineRenderer;
    public float coolDownTime = 5.0f;

    private bool isTongueAvailable = true;


    //Time
    public float time;
    void Start()
    {
        // Get the Line Renderer component
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Check if the tongue attack is available
        if (isTongueAvailable)
        {
            // Check if the player pressed the attack button
            if (Input.GetMouseButtonDown(1))
            {
                // Start the tongue attack
                StartTongueAttack();
            }
        }
    }
    void StartTongueAttack()
    {
        // Set the tongue attack as unavailable
        isTongueAvailable = false;

        // Start the ExtendTongue coroutine
        StartCoroutine(ExtendTongue());

        // Start the cool down coroutine
        StartCoroutine(CoolDown());
    }
    IEnumerator ExtendTongue()
    {
        // Convert the mouse cursor position to a ray in world space
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Check if the ray hits the ground
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Set the end position to the hit point
            endPosition = hit.point;
            endPosition.y = startPosition.position.y;
        }

        // The maximum length of the tongue
        float maxLength = 5.0f;

        // Calculate the direction from the start to the end position
        Vector3 direction = (endPosition - startPosition.position).normalized;

        // Set the end position to the maximum length from the start position
        endPosition = startPosition.position + direction * maxLength;

        // The elapsed time of the tongue extension
        float elapsedTime = 0.0f;

        // Set the initial position of the Line Renderer
        lineRenderer.SetPosition(0, startPosition.position);
        lineRenderer.SetPosition(1, startPosition.position);

        // Enable the Line Renderer
        lineRenderer.enabled = true;

        // Extension loop
        while (elapsedTime < 2.0f)
        {
            // Calculate the extension ratio
            float ratio = elapsedTime / 2.0f;

            // Interpolate between the start and end positions
            Vector3 position = Vector3.Lerp(startPosition.position, endPosition, ratio);

            // Set the y component of the position to the y component of the start position
            position.y = startPosition.position.y;

            // Check if the y component of the position is below the minimum
            if (position.y < minY)
            {
                // Set the y component of the position to the minimum
                position.y = minY;
            }

            // Set the position of the Line Renderer
            lineRenderer.SetPosition(1, position);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Retraction loop
        while (elapsedTime > 0.0f)
        {
            // Calculate the extension ratio
            float ratio = elapsedTime / 2.0f;

            // Interpolate between the start and end positions
            Vector3 position = Vector3.Lerp(startPosition.position, endPosition, ratio);

            // Set the y component of the position to the y component of the start position
            position.y = startPosition.position.y;

            // Check if the y component of the position is below the minimum
            if (position.y < minY)
            {
                // Set the y component of the position to the minimum
                position.y = minY;
            }

            // Set the position of the Line Renderer
            lineRenderer.SetPosition(1, position);

            // Update the elapsed time
            elapsedTime -= Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Disable the Line Renderer
        lineRenderer.enabled = false;
    }

    IEnumerator CoolDown()
    {
        // Wait for the cool down time
        yield return new WaitForSeconds(coolDownTime);

        // Set the tongue attack as available
        isTongueAvailable = true;
    }
}
