using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCutscene : MonoBehaviour
{
    public Image img;
    public GameObject BoatCam;
    public GameObject CutsceneCam;
    public BoatEngine Engine;
    private bool hasFinished = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (img.color.a < 1 && hasFinished == true)
        {
            img.color = new Color(255, 255, 255, img.color.a + 0.001f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.tag == "BoatHull")
        {
            //Debug.Log("==============================");
                
            BoatCam.SetActive(false);
            CutsceneCam.SetActive(true);
            Engine.Finished = true;
            hasFinished = true;

        }    
        
    }
}
