using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeirdText : MonoBehaviour
{
    public RectTransform TextOutline;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextOutline.anchoredPosition = new Vector2(Random.Range(-2,2), Random.Range(-2, 2));
    }
}
