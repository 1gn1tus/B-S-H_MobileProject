using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    [SerializeField]
    [Range(-1,60)]private int FrameRateDesidered;

    [SerializeField]
    [Range(-1, 6)] private int qualityType;

    private void Start()
    {
        if(qualityType >= 0)
        {
            QualitySettings.SetQualityLevel(qualityType);
        }

        if(FrameRateDesidered > 0)
        {
            Application.targetFrameRate = FrameRateDesidered; ;
        }
        else
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }
    }
}
