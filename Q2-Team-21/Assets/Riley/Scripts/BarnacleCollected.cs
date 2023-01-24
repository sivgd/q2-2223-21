using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnacleCollected : MonoBehaviour
{
    //Adrian please dont touch this
    private GameObject player;
    public bool HasFinished;
    public int WaitTime = 600;
    private RectTransform UI;
    public int VisiblePosition;
    public int InvisiblePosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("RileysCanvas");
        UI = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<QuestingStuff>().HasBarnacle == true && HasFinished == false)
        {
            if (UI.position.x > VisiblePosition) UI.position = new Vector3(UI.position.x - 5, UI.position.y, UI.position.z);

            if (UI.position.x <= VisiblePosition) WaitTime--;

            if (WaitTime <= 0) HasFinished = true;
        }

        if (player.GetComponent<QuestingStuff>().HasBarnacle == true && HasFinished == true)
        {
            if (UI.position.x < InvisiblePosition) UI.position = new Vector3(UI.position.x + 5, UI.position.y, UI.position.z);

        }
    }
}
