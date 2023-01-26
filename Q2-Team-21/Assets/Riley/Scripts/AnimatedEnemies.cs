using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedEnemies : MonoBehaviour
{    
    public int UpdateSpeed = 30;
    private int UpdateCycle;
    public Texture[] Frames;
    private int FrameNumber = 0;
    Renderer m_renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        UpdateCycle = UpdateSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCycle--;
        if (UpdateCycle <= 0)
        {
            UpdateCycle = UpdateSpeed;
            FrameNumber++;
        }
        if (FrameNumber >= Frames.Length) FrameNumber = 0;
        

        m_renderer.material.mainTexture = Frames[FrameNumber];


    }
}
