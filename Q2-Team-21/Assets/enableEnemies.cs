using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    private void Start()
    {
        for (int i = 0; i >= enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i >= enemies.Length; i++) { 
            enemies[i].SetActive(true); }
    }
}
