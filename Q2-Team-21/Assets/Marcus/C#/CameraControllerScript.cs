using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    //Raycast

    private LayerMask InteractablesLayerMask;
    private GameObject LookingAtObj;

    //Utility

    public GameObject BoatTXT;
    public GameObject LightTXT;

    void Start()
    {
        //Raycast

        InteractablesLayerMask = LayerMask.GetMask("Interactables");
    }

    void Update()
    {
        //Raycast

        var ray = new Ray(origin: this.transform.position, direction: this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            LookingAtObj = hit.transform.gameObject;
            if (LookingAtObj.tag == "PlayerBoat")
            {
                BoatTXT.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //if (InBoat == false)
                    //{
                        
                    //    BoatTXT.SetActive(false);
                    //}
                }
            }
            if (LookingAtObj.tag == "")
            {

            }
            if (LookingAtObj.tag == "")
            {

            }
        }
        else
        {
            LookingAtObj = null;
        }
    }
}
