using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dialougeTriigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public int x = 0;
    public Canvas UIDUI;
    public bool disableCollider;
    public static GameObject player;

    

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider collision)
    {
        x++;
        Debug.Log(collision.tag);
        if (disableCollider == true && collision.tag == "Player")
        {
            //player.GetComponent<FindMousePositionTest>().enabled = false;
            //player.GetComponent<Animator>().enabled = false;
            //player.GetComponent<Rigidbody>().gravityScale = 0;
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //UIDUI.enabled = true;
            StartDialogue();
            Destroy(gameObject);

        }
        if (disableCollider == false && collision.tag == "Player")
        {
            //player.GetComponent<CharacterControllerScript>().enabled = false;
            //UIDUI.enabled = true;
            StartDialogue();
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        

        
    }
    //private void Update()
    //{
    //    OnLevelWasLoaded(3);
    //}
    
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
