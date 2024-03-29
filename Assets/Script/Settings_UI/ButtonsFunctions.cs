using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    #region movementInput

    [SerializeField]
    private GameObject joystickImage;
    private string inputModeText;
    private int touchMode = 0;
    private int touchModeVertical;
    public GameObject textInputMode;

    #endregion

    #region ref
    private GameObject gameM;
    private GameObject player;

    private Move move;
    private SpeculareMove speculareMove;
    #endregion

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameM = GameObject.FindObjectOfType<FrameRate>().gameObject;

        move = GameObject.FindObjectOfType<Move>();
    }

    public void ChangeInputMoveMode()
    {
        if (gameM.GetComponent<ScreenOrientedInGame>().buttonsInputSettings)
        {
            if (touchMode == 0)
            {
                joystickImage.SetActive(false);
                touchMode = 1;
                inputModeText = "TouchOverFollow";
                textInputMode.GetComponent<Text>().text = inputModeText;
                move.checkMovement = 1;

                if (gameM.GetComponent<SpeculareManager>().isThisLevelSpeculare)
                {
                    speculareMove = player.GetComponent<SpeculareMove>();
                    speculareMove.checkMovementSpeculare = 1;
                }

            }
            else if (touchMode == 1)
            {
                joystickImage.SetActive(true);
                touchMode = 2;
                inputModeText = "TouchFollow";
                textInputMode.GetComponent<Text>().text = inputModeText;
                move.checkMovement = 2;

                if (gameM.GetComponent<SpeculareManager>().isThisLevelSpeculare)
                {
                    speculareMove = player.GetComponent<SpeculareMove>();
                    speculareMove.checkMovementSpeculare = 2;
                }
            }
            else if (touchMode == 2)
            {
                joystickImage.SetActive(false);
                touchMode = 0;
                inputModeText = "TouchJoystick";
                textInputMode.GetComponent<Text>().text = inputModeText;
                move.checkMovement = 0;

                if (gameM.GetComponent<SpeculareManager>().isThisLevelSpeculare)
                {
                    speculareMove = player.GetComponent<SpeculareMove>();
                    speculareMove.checkMovementSpeculare = 0;
                }
            }
            }
            else
            {
              if(touchModeVertical == 0)
              {
                joystickImage.SetActive(false);
                touchModeVertical = 1;
                inputModeText = "TouchOverFollow";
                textInputMode.GetComponent<Text>().text = inputModeText;
                player.GetComponent<MoveVertical>().CheckMoveVertical = 1;
              }
              else if(touchModeVertical == 1)
              {
                joystickImage.SetActive(false);
                touchModeVertical = 0;
                inputModeText = "TouchFollow";
                textInputMode.GetComponent<Text>().text = inputModeText;
                player.GetComponent<MoveVertical>().CheckMoveVertical = 0;
            }
                
            }
        }
    }
