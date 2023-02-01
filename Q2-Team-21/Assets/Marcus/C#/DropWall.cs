using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWall : MonoBehaviour
{
    public GameObject wall;
    public GameObject WallCam;
    public GameObject PlayerCam;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerCam.SetActive(false);
            WallCam.SetActive(true);
            wall.GetComponent<Animator>().SetBool("PurlTurnedIn", true);
            StartCoroutine(ResetCams());
        }
    }

    IEnumerator ResetCams()
    {
        yield return new WaitForSeconds(5f);
        PlayerCam.SetActive(true);
        WallCam.SetActive(false);
    }
}
