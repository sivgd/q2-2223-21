using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPointScript : MonoBehaviour
{
    public bool active;
    [SerializeField] GameObject Bulb;

    void Start()
    {
        
    }

    void Update()
    {
        if (active == true)
        {
            Bulb.GetComponent<Animator>().SetBool("LightSet", true);
        }
    }
}
