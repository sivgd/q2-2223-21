using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour
{
    public int CreditsNumber;
    
    void Update()
    {
        if (CreditsNumber < 0) CreditsNumber = 6;
        if (CreditsNumber > 6) CreditsNumber = 0;
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
