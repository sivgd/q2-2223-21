using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlast : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * speed;

        if(player.GetComponent<Player>().health == 0 || GameObject.FindGameObjectsWithTag("Player") == null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestoryAfterTime(gameObject));
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Player>().health--;
            Destroy(gameObject);
        }
    }
    IEnumerator DestoryAfterTime(GameObject bullet)
    {
       
        yield return new WaitForSeconds(3);
        Destroy(bullet);
    }
}
