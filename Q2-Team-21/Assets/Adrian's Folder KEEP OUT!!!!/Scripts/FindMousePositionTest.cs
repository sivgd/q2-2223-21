using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMousePositionTest : MonoBehaviour
{

    public float movespeed;
    private Rigidbody2D rb2;
    private SpriteRenderer sr;
    private Animator ani;
    public bool isWalking;
    public bool facingNorth;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        ani = gameObject.GetComponent<Animator>();
        isWalking = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log(worldPosition);
        Vector3 move = transform.position;
        worldPosition = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
        worldPosition -= move;

        Vector3 movement = worldPosition.normalized * movespeed;


        if (Input.GetMouseButton(1) == true)
        {
            
            rb2.velocity = movement;
            isWalking = true;
            
        }
        else
        {
            rb2.velocity = Vector3.zero;
            isWalking = false;
        }

        if (movement.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        if (movement.y < 0)
        {
            facingNorth = false;
        }
        else
        {
            facingNorth = true;
        }

        ani.SetBool("Walking", isWalking);
        ani.SetBool("FacingNorth", facingNorth);
    }
}
