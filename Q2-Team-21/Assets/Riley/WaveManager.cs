using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;
    public float amplitude2 = 0.5f;
    public float length2 = 10f;
    public float speed2 = 0.5f;
    public float offset2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, detroying...");
            Destroy(this);
        }
    }


    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        offset2 += Time.deltaTime * speed2;
    }


    public float GetWaveHeight(float _x, float _z)
    {
        return (amplitude * Mathf.Sin(_x / length + offset)) + (amplitude2 * Mathf.Sin(_z / length2 + offset2));
    }



}
