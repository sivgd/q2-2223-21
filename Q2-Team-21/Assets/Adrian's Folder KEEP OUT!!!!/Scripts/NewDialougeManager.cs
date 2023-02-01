using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewDialougeManager : MonoBehaviour
{
    public float Speed;
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public GameObject player;
    public int xray = 0;
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public BoatEngine engine;
    public RotateAroundCam cam;
    public CharacterControllerScript cam2;
    


    public void OpenDialogue(Message[] messages, Actor[] actors, GameObject gameobjects)
    {

        //player.GetComponent<FindMousePositionTest>().enabled = false;
        engine.GetComponent<BoatEngine>().enabled = false;
        cam.GetComponent<RotateAroundCam>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<CharacterControllerScript>().enabled = false;

        
        cam2.GetComponent<CharacterControllerScript>().enabled = false;

        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        gameobjects.GetComponent<SphereCollider>().enabled = false;
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        
        DisplayMessage();
    }
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        cam.GetComponent<RotateAroundCam>().enabled = false;
        player.GetComponent<CharacterControllerScript>().enabled = false;
        gameObject.GetComponent<Canvas>().enabled = true;
        //player.GetComponent<FindMousePositionTest>().enabled = false;
        engine.GetComponent<BoatEngine>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        DisplayMessage();
    }
    

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(messageToDisplay.message));

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }
    IEnumerator TypeSentence(string sentence)
    {
        messageText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            yield return new WaitForSeconds(Speed);
            messageText.text += letter;
            yield return null;
        }
    }
    public void NextMessage()
    {
        xray++;
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            cam.GetComponent<RotateAroundCam>().enabled = true;
            player.GetComponent<CharacterControllerScript>().enabled = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            
            //player.GetComponent<FindMousePositionTest>().enabled = true;
            gameObject.GetComponent<Canvas>().enabled = false;
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    
}
