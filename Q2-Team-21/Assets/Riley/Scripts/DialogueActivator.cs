using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    private QuestingStuff Quester;
    public GameObject GotPearlDialogue;
    public GameObject DeliveredBarrelDialogue;
    public GameObject BrokeCoralDialogue;


    // Start is called before the first frame update
    void Start()
    {
        Quester = GameObject.FindGameObjectWithTag("RileysCanvas").GetComponent<QuestingStuff>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Quester.HasPearl == true) GotPearlDialogue.SetActive(true);
        if (Quester.HasBarnacle == true) DeliveredBarrelDialogue.SetActive(true);
        if (Quester.HasDestroyedCoral == true) BrokeCoralDialogue.SetActive(true);



    }
}
