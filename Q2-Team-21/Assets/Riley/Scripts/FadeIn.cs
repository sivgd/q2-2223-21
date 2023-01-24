using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class FadeIn : MonoBehaviour
{
    public Image img;
    
    // Start is called before the first frame update
    void Start()
    {
        
        img = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        img.tintColor = Color.white;
        Debug.Log(img.tintColor.a);
       
        this.GetComponent<Image>().tintColor = new Color(0, 0, 0, img.tintColor.a-5);
        
    }
}
