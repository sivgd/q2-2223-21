using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    private float timer;
    public float speed;
    public float health = 10;
    public float maxHealth = 50;
    private Rigidbody rb;
    public float rotationSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //rb.useGravity =false;
    }

    // Update is called once per frame
    GameObject[] childrenWithTag;
    void Update()
    {
        try
        {
            List<GameObject> childrenWithTagList = new List<GameObject>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.CompareTag("Wave1") || child.CompareTag("Wave2"))
                {
                    childrenWithTagList.Add(child.gameObject);
                }
            }
            childrenWithTag = childrenWithTagList.ToArray();

            if (childrenWithTag.Length <= 5)
            {
                health += 1 * Time.deltaTime;
            }

            health = Mathf.Clamp(health, 0, maxHealth);

            if (health == 0 && GameObject.Find("Player").GetComponent<TransitionHandler>().InBoat == true)
            {
                GameObject.FindWithTag("PlayerBoat").GetComponent<BoatEngine>().enabled =false;
            }
            else if(health >= 1 && GameObject.Find("Player").GetComponent<TransitionHandler>().InBoat == true)
            {
                GameObject.FindWithTag("PlayerBoat").GetComponent<BoatEngine>().enabled = true;
            }
        }
        catch (NullReferenceException)
        {
            // Do nothing
        }
    }
}

