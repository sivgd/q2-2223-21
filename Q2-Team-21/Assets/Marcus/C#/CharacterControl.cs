using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        gameObject.transform.forward += new Vector3(0, z, 0) * Time.deltaTime;
        gameObject.transform.Rotate(new Vector3(0, 0, x) * Time.deltaTime);
    }
}