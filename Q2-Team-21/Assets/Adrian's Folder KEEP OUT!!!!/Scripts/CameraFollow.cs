using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    // The offset of the camera from the player
    public Vector3 offset;

    void Update()
    {
        // Set the position of the camera to the player's position plus the offset
        transform.position = player.transform.position + offset;

        // Rotate the camera to look at the player from the top-down view
        // transform.LookAt(player.transform, Vector3.up);
    }
}
