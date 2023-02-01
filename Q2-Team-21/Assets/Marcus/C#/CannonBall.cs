using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DeleteBall());
    }

    IEnumerator DeleteBall()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
