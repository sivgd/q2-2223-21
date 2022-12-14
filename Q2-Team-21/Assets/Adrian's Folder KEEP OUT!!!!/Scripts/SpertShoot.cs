using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpertShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Transform bulletPos;
    public float time;
    private float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > time)
        {
            timer = 0;

            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
