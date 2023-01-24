using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image img;
    public float alpha;
    
    // Start is called before the first frame update
    void Start()
    {
        
        img = GetComponent<Image>();
        

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //img.color = Color.white;
        Debug.Log(img.color.a);
        if (img.color.a > 0)
        {
            this.GetComponent<Image>().color = new Color(0, 0, 0, img.color.a - 0.0005f);
        }
        
    }
}
