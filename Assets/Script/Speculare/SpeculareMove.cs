using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeculareMove : MonoBehaviour
{
    #region Movement

    private Touch touch;
    private Rigidbody2D rigidbody2d;
    private float overTouch = 0.5f;
    [Range(30, 100)] public float TouchspeedSpeculare;

    #endregion

    #region inputmode

    private VirtualJoystick virtualJoystick;
    [System.NonSerialized] public int checkMovementSpeculare = 0;

    #endregion

    [System.NonSerialized]
    public float screenMaxHeight;
    [Range(0, 50)] public float JoystickSpeed;

    private void Awake()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        switch (checkMovementSpeculare)
        {
            case 0:

                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touch.position);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-screenToWorld.x, Mathf.Clamp(-screenToWorld.y,-screenMaxHeight,screenMaxHeight), 0), TouchspeedSpeculare * Time.deltaTime); //Vector3.LerpUnclamped(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
                    }
                }

                else
                {
                    rigidbody2d.velocity = Vector2.zero;
                }

                break;

            case 1:

                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touch.position);
                    if (touch.phase == TouchPhase.Began)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(screenToWorld.x, screenToWorld.y, 0), (10 * TouchspeedSpeculare) * Time.deltaTime);
                    }

                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-screenToWorld.x, -screenToWorld.y + overTouch), TouchspeedSpeculare * Time.deltaTime);
                    }

                    else
                    {
                        rigidbody2d.velocity = Vector2.zero;
                    }
                }

                break;

            case 2:

                virtualJoystick = GameObject.FindObjectOfType<VirtualJoystick>();
                if (virtualJoystick.inputDir != Vector3.zero)
                {
                    this.gameObject.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3(-virtualJoystick.inputDir.x, -virtualJoystick.inputDir.z, 0), JoystickSpeed * Time.deltaTime);
                }

                else
                {
                    rigidbody2d.velocity = Vector2.zero;
                }

                break;
        }
    }
}
