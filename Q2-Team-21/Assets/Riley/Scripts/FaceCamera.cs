using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    //Adrian please dont touch this
    private GameObject Camera;
    public float DegreesRotate;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 VectorToPlayer = new Vector3(Camera.transform.position.x - transform.position.x, 0, Camera.transform.position.z - transform.position.z).normalized;

        DegreesRotate = Mathf.Atan2(VectorToPlayer.x, VectorToPlayer.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(90, DegreesRotate, 0);
    }
}
