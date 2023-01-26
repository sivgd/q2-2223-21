using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    //Adrian please dont touch this
    private GameObject player;
    private GameObject Boat;
    public float DegreesRotate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        Boat = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeInHierarchy == true)
        {
            Vector3 VectorToPlayer = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z).normalized;

            DegreesRotate = Mathf.Atan2(VectorToPlayer.x, VectorToPlayer.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(90, DegreesRotate, 0);
        }
        else
        {
            Vector3 VectorToBoat = new Vector3(Boat.transform.position.x - transform.position.x, 0, Boat.transform.position.z - transform.position.z).normalized;

            DegreesRotate = Mathf.Atan2(VectorToBoat.x, VectorToBoat.z) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(90, DegreesRotate, 0);
        }



        

    }
}
