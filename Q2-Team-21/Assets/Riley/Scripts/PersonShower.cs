using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonShower : MonoBehaviour
{
    //Adrian please dont touch this
    public GameObject PersonsCredits;
    public GameObject CreditsMenu;
    public int CreditsPlace;
    // Update is called once per frame
    void Update()
    {
        if(CreditsMenu.GetComponent<CreditsScene>().CreditsNumber == CreditsPlace)
        {
            PersonsCredits.SetActive(true);
        }
        else
        {
            PersonsCredits.SetActive(false);
        }

        
    }
}
