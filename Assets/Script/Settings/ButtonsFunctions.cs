using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    public GameObject textObject;
    private string inputModeText;
    private bool touchMode = false;
    private Move move;

    private void Start()
    {
        move = GameObject.FindObjectOfType<Move>();
    }

    public void ChangeInputMoveMode()
    {
        if (!touchMode)
        {
            touchMode = true;
            inputModeText = "TouchOverFollow";
            textObject.GetComponent<Text>().text = inputModeText;
            move.checkMovement = 1;

        }
        else
        { 
            touchMode = false;
            inputModeText = "TouchFollow";
            textObject.GetComponent<Text>().text = inputModeText;
            move.checkMovement = 0;
        }
    }
}
