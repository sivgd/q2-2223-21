using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidDialogue : MonoBehaviour
{
    //Adrian please dont touch this
    public GameObject Player;
    public bool HasGivenQuest = false;

    public GameObject DialogueQuestIntroduction;
    public GameObject DialogueNoProgress;
    public GameObject DialogueQuestComplete;
    public GameObject DialogueQuestSamaritan;
    public GameObject DialogueAfterQuest;


    // Start is called before the first frame update
    void Start()
    {
        DialogueQuestIntroduction.SetActive(false);
        DialogueNoProgress.SetActive(false);
        DialogueQuestComplete.SetActive(false);
        DialogueQuestSamaritan.SetActive(false);
        DialogueAfterQuest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<QuestingStuff>().InSpeakingRange == true)
        {

            //Introduction, No pearl, not talked
            if (Player.GetComponent<QuestingStuff>().HasReturnedPearl == false && Player.GetComponent<QuestingStuff>().HasPearl == false && HasGivenQuest == false && Player.GetComponent<QuestingStuff>().HasSomethingToSay == true)
            {
                Player.GetComponent<QuestingStuff>().HasSomethingToSay = false;
                
                DialogueQuestIntroduction.SetActive(true);
                HasGivenQuest = true;
            }

            //No progress: No pearl, has talked
            if (Player.GetComponent<QuestingStuff>().HasReturnedPearl == false && Player.GetComponent<QuestingStuff>().HasPearl == false && HasGivenQuest == true && Player.GetComponent<QuestingStuff>().HasSomethingToSay == true)
            {
                Player.GetComponent<QuestingStuff>().HasSomethingToSay = false;
                DialogueNoProgress.SetActive(true);
            }

            //Quest Complete: Yes pearl, has talked
            if (Player.GetComponent<QuestingStuff>().HasReturnedPearl == false && Player.GetComponent<QuestingStuff>().HasPearl == true && HasGivenQuest == true && Player.GetComponent<QuestingStuff>().HasSomethingToSay == true)
            {
                Player.GetComponent<QuestingStuff>().HasSomethingToSay = false;
                Player.GetComponent<QuestingStuff>().HasReturnedPearl = true;
                DialogueQuestComplete.SetActive(true);
            }

            //Quest Samaritan: Yes pearl, not talked
            if (Player.GetComponent<QuestingStuff>().HasReturnedPearl == false && Player.GetComponent<QuestingStuff>().HasPearl == true && HasGivenQuest == false && Player.GetComponent<QuestingStuff>().HasSomethingToSay == true)
            {
                Player.GetComponent<QuestingStuff>().HasSomethingToSay = false;
                Player.GetComponent<QuestingStuff>().HasReturnedPearl = true;
                DialogueQuestSamaritan.SetActive(true);
            }

            //After quest: Has returned pearl.
            if (Player.GetComponent<QuestingStuff>().HasReturnedPearl == true && Player.GetComponent<QuestingStuff>().HasSomethingToSay == true)
            {
                Player.GetComponent<QuestingStuff>().HasSomethingToSay = false;
                DialogueAfterQuest.SetActive(true);
            }



        }
        if (Player.GetComponent<QuestingStuff>().InSpeakingRange == false)
        {
            DialogueQuestIntroduction.SetActive(false);
            DialogueNoProgress.SetActive(false);
            DialogueQuestComplete.SetActive(false);
            DialogueQuestSamaritan.SetActive(false);
            DialogueAfterQuest.SetActive(false);
        }
    }
}
