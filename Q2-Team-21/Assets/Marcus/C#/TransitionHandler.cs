using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionHandler : MonoBehaviour
{
    [SerializeField] GameObject Boat;
    [SerializeField] GameObject FPS;
    [SerializeField] GameObject BoatCam;
    [SerializeField] GameObject FPSCam;
    [SerializeField] GameObject FPSOnBoat;
    public bool InBoat;
    public bool dead;

    void Start()
    {
        ExitBoat();
    }

    private void Update()
    {
        if (InBoat == true)
        {
            FPS.transform.position = FPSOnBoat.transform.position;
        }
    }

    private void LateUpdate()
    {
        if(dead == true)
        {
            EnterBoat();
            StartCoroutine(UnDeath());
            dead = false;
        }
    }

    IEnumerator UnDeath()
    {
        yield return new WaitForSeconds(.1f);
        ExitBoat();
    }

    public void EnterBoat()
    {
        FPS.GetComponent<CharacterController>().enabled = false;
        FPSCam.SetActive(false);
        Boat.GetComponent<BoatEngine>().enabled = true;
        BoatCam.SetActive(true);
        InBoat = true;
    }

    public void ExitBoat()
    {
        Boat.GetComponent<BoatEngine>().enabled = false;
        BoatCam.SetActive(false);
        FPS.GetComponent<CharacterController>().enabled = true;
        FPSCam.SetActive(true);
        InBoat=false;
        StopAllCoroutines();
    }
}
