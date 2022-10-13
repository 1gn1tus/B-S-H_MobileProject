using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour,IinputProvider
{
    #region Movement

    private Touch touch;
    private Rigidbody2D rigidbody2d;
    private float overTouch = 0.5f;
    [Range(30, 100)] public float Touchspeed;

    #endregion

    #region inputmode

    [System.NonSerialized] public int checkMovement = 0;
    private VirtualJoystick virtualJoystick;

    #endregion

    #region speed
    private float currentSpeed;
    private float maxSpeed;

    [Range(0,50)]public float JoystickSpeed;
    #endregion

    public bool testForPc;
    public float pcSpeed;

    private void Awake()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
        maxSpeed = Touchspeed;
    }
    private void Update()
    {
        if (testForPc)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.gameObject.transform.position += Vector3.up * pcSpeed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                this.gameObject.transform.position += Vector3.left * pcSpeed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                this.gameObject.transform.position += Vector3.down * pcSpeed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.gameObject.transform.position += Vector3.right * pcSpeed * Time.deltaTime;
            }
        }

        switch (checkMovement)
        {
            case 0:

                if (Input.touchCount > 0)
                {
                    currentSpeed = PlayerSpeed();
                    touch = Input.GetTouch(0);
                    Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touch.position);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(screenToWorld.x, screenToWorld.y ,0), Touchspeed * Time.deltaTime); //Vector3.LerpUnclamped(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
                    }
                    if (currentSpeed > maxSpeed)
                    {
                        rigidbody2d.velocity = new Vector2(maxSpeed, maxSpeed);
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
                        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(screenToWorld.x, screenToWorld.y, 0),(10 * Touchspeed) * Time.deltaTime);
                    }
                   
                    if (touch.phase == TouchPhase.Moved)
                    {
                        currentSpeed = PlayerSpeed();
                        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(screenToWorld.x, screenToWorld.y + overTouch), Touchspeed * Time.deltaTime);
                        if (currentSpeed > maxSpeed)
                        {
                            rigidbody2d.velocity = new Vector2(maxSpeed, maxSpeed);
                        }
                    }
                    else
                    {
                        rigidbody2d.velocity = Vector2.zero;
                    }
                }

                break;

            case 2:

                virtualJoystick = GameObject.FindObjectOfType<VirtualJoystick>();
                if(virtualJoystick.inputDir != Vector3.zero)
                {
                    this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + new Vector3(virtualJoystick.inputDir.x, virtualJoystick.inputDir.z, 0), JoystickSpeed * Time.deltaTime);
                }

                else
                {
                    rigidbody2d.velocity = Vector2.zero;
                }

                break;
        }
    }

    public float PlayerSpeed()
    {
        this.currentSpeed = rigidbody2d.velocity.magnitude;
        return this.currentSpeed;
    }
}
