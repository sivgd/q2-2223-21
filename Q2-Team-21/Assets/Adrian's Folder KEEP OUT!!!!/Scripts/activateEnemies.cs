using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateEnemies : MonoBehaviour
{
    public string wave;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoatHull"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(wave);
            Debug.Log("Number of enemies found: " + enemies.Length);
            foreach (GameObject enemy in enemies)
            {
                Debug.Log(enemy.tag);
                enemy.GetComponent<MoveTowardsPlayer>().enabled = true;
            }
        }
    }
}

