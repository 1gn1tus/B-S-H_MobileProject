using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    #region movementInput

    public GameObject textInputMode;
    private string inputModeText;
    private bool touchMode = false;

    #endregion

    #region ref

    private Move move;

    #endregion

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
            textInputMode.GetComponent<Text>().text = inputModeText;
            move.checkMovement = 1;

        }
        else
        { 
            touchMode = false;
            inputModeText = "TouchFollow";
            textInputMode.GetComponent<Text>().text = inputModeText;
            move.checkMovement = 0;
        }
    }
}
