using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LightingProgression : MonoBehaviour
{
    private Color FadingcolorRegulator;
    [SerializeField]
    private Color Fadingcolor;
    [SerializeField]
    private GameObject[] backGrounds;
    [SerializeField]
    private float FadeVelocity;
    public bool StartLighting;

    void Update()
    {
        if (StartLighting)
        {
            FadingcolorRegulator = new Color(Mathf.Lerp(backGrounds[0].GetComponent<SpriteRenderer>().color.r,Fadingcolor.r,FadeVelocity + Time.deltaTime), Mathf.Lerp(backGrounds[0].GetComponent<SpriteRenderer>().color.g, Fadingcolor.g, FadeVelocity + Time.deltaTime), Mathf.Lerp(backGrounds[0].GetComponent<SpriteRenderer>().color.b, Fadingcolor.b, FadeVelocity + Time.deltaTime), 255);

            for(int i = 0; i < backGrounds.Length; i++)
            {
                backGrounds[i].GetComponent<SpriteRenderer>().color = FadingcolorRegulator;
            }

            if(FadingcolorRegulator.r >= 1)
            {
                StartLighting = false;
            }
        }
    }
}
