using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlCollectAnnouncment : MonoBehaviour
{
    //Adrian please dont touch this
    public GameObject player;
    public bool HasFinished;
    public int WaitTime = 600;
    private RectTransform UI;
    public int VisiblePosition;
    public int InvisiblePosition;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<QuestingStuff>().HasPearl == true && HasFinished == false)
        {
            if (UI.position.x > VisiblePosition) UI.position = new Vector3(UI.position.x - 1, UI.position.y, UI.position.z);

            if (UI.position.x <= VisiblePosition) WaitTime--;

            if (WaitTime <= 0) HasFinished = true;
        }

        if (player.GetComponent<QuestingStuff>().HasPearl == true && HasFinished == true)
        {
            if (UI.position.x < InvisiblePosition) UI.position = new Vector3(UI.position.x + 1, UI.position.y, UI.position.z);

        }
    }
}
