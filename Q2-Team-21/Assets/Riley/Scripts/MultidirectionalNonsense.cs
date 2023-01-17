using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultidirectionalNonsense : MonoBehaviour
{
    public FaceCamera Image;
    public WhatDirection RealBody;
    public string direction;
    public float Determiner;
    Renderer m_renderer;
    public Texture FrogToward, FrogAway, FrogLeft, FrogRight;
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Determiner = Image.DegreesRotate - RealBody.DirectionFacing;
        if (Determiner < 0) Determiner += 360;
        if (Determiner > 360) Determiner -= 360;
        //Debug.Log(Determiner);

        if(Determiner >= 315 || Determiner <= 45)
        {
            direction = "Towards";
            m_renderer.material.mainTexture = FrogToward;
        }
        else if(Determiner >= 135 && Determiner <= 225)
        {
            direction = "Away";
            m_renderer.material.mainTexture = FrogAway;
        }
        else if(Determiner > 45 && Determiner < 135)
        {
            direction = "Left";
            m_renderer.material.mainTexture = FrogLeft;
        }
        else if(Determiner > 225 && Determiner < 315)
        {
            direction = "right";
            m_renderer.material.mainTexture = FrogRight;
        }






    }
}
