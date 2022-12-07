using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeldTest : MonoBehaviour
{
    public string ItemHeld;
    public bool InUse;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (ItemHeld)
        {
            case "crime":
                break;

            default:
                //Debug.Log("Something went wrong, your holding nothing");
                break;
        }
        
    }
}
