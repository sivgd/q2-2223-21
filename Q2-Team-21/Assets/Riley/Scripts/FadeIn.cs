using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image img;
    
    public int WaitTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
        img = GetComponent<Image>();
        

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (WaitTime > 0) WaitTime--;
        //img.color = Color.white;
        //Debug.Log(img.color.a);
        if (img.color.a > 0 && WaitTime <= 0) 
        {
            this.GetComponent<Image>().color = new Color(0, 0, 0, img.color.a - 0.005f);
            
        }
        if(img.color.a<=0.75f && WaitTime<=0) this.GetComponent<Image>().color = new Color(0, 0, 0, img.color.a - 0.005f);
        if (img.color.a<=0) this.gameObject.SetActive(false);
    }
}
