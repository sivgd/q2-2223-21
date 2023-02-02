using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutscene : MonoBehaviour
{
    public GameObject BoatCam;
    public GameObject CutsceneCam;
    public BoatEngine Engine;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

            BoatCam.SetActive(false);
            CutsceneCam.SetActive(true);
            Engine.Finished = true;
        
    }
}
