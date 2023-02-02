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
    [SerializeField] GameObject secondConvo;
    [SerializeField] GameObject firstConvo;
    [SerializeField] GameObject Pearl;

    [SerializeField] GameObject WallLower;
    [SerializeField] GameObject WallCam;
    [SerializeField] Cannon canon;
    [SerializeField] GameObject Frogelme;
    public bool cannonBallsCollected;
    public bool InBoat;
    public bool dead;

    void Start()
    {
        ExitBoat();
        Frogelme.GetComponent<MeshRenderer>().enabled = false;
        Frogelme.GetComponent<FrogController>().enabled = false;
    }

    private void Update()
    {
        if (InBoat == true)
        {
            FPS.transform.position = FPSOnBoat.transform.position;
        }

        if (Boat.GetComponent<BoatEngine>().pearlCollected == true)
        {
            firstConvo.SetActive(false);
            secondConvo.SetActive(true);
            Pearl.SetActive(false);
        }

        if (Boat.GetComponent<BoatEngine>().cannonBallCollected == true)
        {
            cannonBallsCollected = true;
            canon.enabled = true;
        }
        else if (FPS.GetComponent<CharacterControllerScript>().cannonBallCollected == true)
        {
            cannonBallsCollected = true;
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
        Frogelme.GetComponent<MeshRenderer>().enabled = true;
        Frogelme.GetComponent<FrogController>().enabled = true;
        if (cannonBallsCollected == true)
        {
            canon.enabled = true;
        }
        else
        {
            canon.enabled = false;
        }
    }

    public void ExitBoat()
    {
        Boat.GetComponent<BoatEngine>().enabled = false;
        BoatCam.SetActive(false);
        FPS.GetComponent<CharacterController>().enabled = true;
        FPSCam.SetActive(true);
        InBoat=false;
        Frogelme.GetComponent<MeshRenderer>().enabled = false;
        Frogelme.GetComponent<FrogController>().enabled = false;
        StopAllCoroutines();
        canon.enabled = false;
    }
}
