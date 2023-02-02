using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour
{
    //Adrian please dont touch this
    public int CreditsNumber;
    
    void Update()
    {
        if (CreditsNumber < 0) CreditsNumber = 7;
        if (CreditsNumber > 7) CreditsNumber = 0;
    }

    public void CreditsNumberDown() 
    {
        CreditsNumber--;
    }
    public void CreditsNumberUp()
    {
        CreditsNumber++;
    }


}
