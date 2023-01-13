using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dialougeTriigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public static int x = 0;
    public Canvas UIDUI;
    public bool disableCollider;
    public static GameObject player;

    private void Awake()
    {
        x = 1;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.tag);
        if (x == 1 && disableCollider == true && collision.tag != "blood")
        {
            player.GetComponent<FindMousePositionTest>().enabled = false;
            //player.GetComponent<Animator>().enabled = false;
            //player.GetComponent<Rigidbody>().gravityScale = 0;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //UIDUI.enabled = true;
            StartDialogue();
            Destroy(gameObject);

        }
        if (x == 1 && disableCollider == false && collision.tag != "blood")
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0,0);
            //UIDUI.enabled = true;
            StartDialogue();
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }

        
    }
    //private void Update()
    //{
    //    OnLevelWasLoaded(3);
    //}
    private void OnLevelWasLoaded(int level)
    {
        StartDialogue();
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (x != 1)
    //    {
    //        player.GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
    //        //UIDUI.enabled = true;
    //        StartDialogue();
    //        gameObject.GetComponent<SphereCollider>().enabled = false;
    //        x = 1;
    //    }
    //}
    
    public void StartDialogue()
    {
        FindObjectOfType<NewDialougeManager>().OpenDialogue(messages, actors);
    }
    public void StartDialogue(GameObject collider)
    {
        FindObjectOfType<NewDialougeManager>().OpenDialogue(messages, actors, collider);
    }
}
[System.Serializable]
public class Message
{
    public int actorId;
    public string message;

}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
