using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private IInputReceiver inputReceiver;
    private Vector3 up = Vector3.up;
    private bool isTouchingTheScreen;
    
    private void Awake()
    {
        inputReceiver = GameObject.FindObjectOfType<IInputReceiver>();
    }

    private void Update()
    {
        #region touchScreen
        if (Input.touchCount > 0)
        {
            isTouchingTheScreen = true;
        }
        else
        {
            isTouchingTheScreen = false;
        }
        #endregion

        /*if ()
        {
            this.gameObject.transform.Translate(inputReceiver.Direction(up));
        }*/
    }
}
