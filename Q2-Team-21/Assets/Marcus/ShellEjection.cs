using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellEjection : MonoBehaviour
{
    public GameObject ShellPrefab;
    public Vector3 ShellEjectionPoint;

    void Update()
    {
        Vector3 ShellEjectionPoint = gameObject.transform.position;
        if (Input.GetKeyUp(KeyCode.E))
        {
            //Instantiate(ShellPrefab, ShellEjectionPoint);
        }
    }
}
