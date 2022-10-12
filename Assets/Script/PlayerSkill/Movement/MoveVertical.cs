using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    #region Movement

    private Touch touch;
    private Rigidbody2D rigidbody2d;
    [Range(30, 100)] public float Touchspeed;
    [System.NonSerialized] public int CheckMoveVertical;

    #endregion

    #region speed
    private float currentSpeed;
    private float maxSpeed;

    [Range(0, 50)] public float JoystickSpeed;
    #endregion

    private void Awake()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
        maxSpeed = Touchspeed;
    }
    private void Update()
    {
       switch (CheckMoveVertical)
        {
            case 0:
                if (Input.touchCount > 0)
                {
                    currentSpeed = PlayerSpeed();
                    touch = Input.GetTouch(0);
                    Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(screenToWorld.x, this.transform.position.y, 0), Touchspeed * Time.deltaTime); //Vector3.LerpUnclamped(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
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
                    currentSpeed = PlayerSpeed();
                    touch = Input.GetTouch(0);
                    Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touch.phase == TouchPhase.Began)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(screenToWorld.x,this.transform.position.y, 0), (10 * Touchspeed) * Time.deltaTime);
                    }

                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(screenToWorld.x, this.transform.position.y, 0), Touchspeed * Time.deltaTime); //Vector3.LerpUnclamped(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
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

        }
    }

    public float PlayerSpeed()
    {
        this.currentSpeed = rigidbody2d.velocity.magnitude;
        return this.currentSpeed;
    }
}
