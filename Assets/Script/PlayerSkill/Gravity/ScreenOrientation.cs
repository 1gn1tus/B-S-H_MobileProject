using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    public bool isOrizzontalOriented;
    private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GravityManager>().gameObject;
    }

    private void Start()
    {
        if (!isOrizzontalOriented)
        {
            Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = UnityEngine.ScreenOrientation.LandscapeRight;
            gameManager.GetComponent<GravityManager>().enabled = true;

        }
    }
}
