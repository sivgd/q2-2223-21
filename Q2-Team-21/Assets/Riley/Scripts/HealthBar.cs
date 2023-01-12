using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float healthCurrent;
    public float healthMax;
    public GameObject HpBar;
    public GameObject HealthMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float healthPercent = (healthCurrent / healthMax) * 80;

        if (healthPercent > 100) healthPercent = 100;
        if (healthPercent < 0) healthPercent = 0;

        HpBar.GetComponent<RectTransform>().anchoredPosition = new Vector3(80-healthPercent, 0, 0);
        HealthMask.GetComponent<RectTransform>().anchoredPosition = new Vector3(-3 * (80-healthPercent), 0, 0);
    }
}
