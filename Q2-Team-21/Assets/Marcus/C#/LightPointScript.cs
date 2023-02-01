using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPointScript : MonoBehaviour
{
    public bool active;
    [SerializeField] GameObject Bulb;
    [SerializeField] GameObject Pearl;

    void Start()
    {
        Pearl.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (active == true)
        {
            Bulb.GetComponent<Animator>().SetBool("LightSet", true);
            StartCoroutine(PearlFall());
        }
    }

    IEnumerator PearlFall()
    {
        yield return new WaitForSeconds(3f);
        Pearl.GetComponent<Rigidbody>().isKinematic = false;
    }
}
