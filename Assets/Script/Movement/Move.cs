using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private IInputReceiver inputReceiver;
    private Vector3 up = Vector3.up;
    
    private void Awake()
    {
        inputReceiver = GameObject.FindObjectOfType<IInputReceiver>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.transform.Translate(inputReceiver.Direction(up));
        }
    }
}
