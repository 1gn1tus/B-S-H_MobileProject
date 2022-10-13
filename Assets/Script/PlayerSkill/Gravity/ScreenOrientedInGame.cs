using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientedInGame : MonoBehaviour
{
    private GameObject gameManager;
    [System.NonSerialized] public bool buttonsInputSettings = true;

    public bool isOrizzontalOriented;

    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<GravityManager>().gameObject;
    }
  
    private void Start()
    {
        if (!isOrizzontalOriented)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }

        else
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
            gameManager.GetComponent<GravityManager>().enabled = true;
            buttonsInputSettings = false;
        }
    }
}
