using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestingStuff : MonoBehaviour
{
    //Adrian please dont touch this
    public bool HasPearl;
    public bool HasBarnacle;
    public bool HasReturnedPearl;
    public bool InSpeakingRange;
    public bool HasDestroyedCoral;
    public bool HasSomethingToSay;
    public GameObject Barnacle;
    public GameObject Mermaid;
    public GameObject pearl;
    public GameObject Boat;


    // Start is called before the first frame update
    void Start()
    {
        HasSomethingToSay = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(Boat.transform.position, Mermaid.transform.position));
        if(Vector3.Distance(Boat.transform.position, pearl.transform.position) < 10)
        {
            HasPearl = true;
            pearl.SetActive(false);
        }

        if (Vector3.Distance(Boat.transform.position, Barnacle.transform.position) < 20)
        {
            HasBarnacle = true;
            Barnacle.SetActive(false);
        }

        if (Vector3.Distance(Boat.transform.position, Mermaid.transform.position) < 30)
        {
            InSpeakingRange= true;
        }
        else
        {
            InSpeakingRange= false;
            HasSomethingToSay = true;
        }


    }
}
