using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    [SerializeField]
    [Range(-1,60)]private int FrameRateDesidered;

    private void Start()
    {
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
