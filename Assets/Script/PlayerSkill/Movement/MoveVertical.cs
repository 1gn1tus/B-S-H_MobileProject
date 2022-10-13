using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    #region Movement

    private Touch touch;
    private Rigidbody2D rigidbody2d;
    [Range(0, 200)] public float TouchspeedVertical;
    [System.NonSerialized] public int CheckMoveVertical;

    #endregion

    [Range(0, 50)] public float JoystickSpeed;

    private void Awake()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       switch (CheckMoveVertical)
        {
            case 0:
                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, new Vector3(screenToWorld.x, this.transform.position.y, this.transform.position.z), TouchspeedVertical * Time.deltaTime); //Vector3.LerpUnclamped(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
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
                        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, new Vector3(screenToWorld.x, this.transform.position.y, this.transform.position.z), (10 * TouchspeedVertical) * Time.deltaTime);
                    }

                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, new Vector3(screenToWorld.x, this.transform.position.y, this.transform.position.z), TouchspeedVertical * Time.deltaTime); //Vector3.LerpUnclamped(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
                    }
                }

                else
                {
                    rigidbody2d.velocity = Vector2.zero;
                }
                break;

        }
    }
}
