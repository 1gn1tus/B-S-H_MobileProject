using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour,IinputProvider
{
    #region Movement

    private Touch touch;
    private Rigidbody2D rigidbody2;
    private const float lerp = 0.7355f;
    private Vector2 overTouch = new Vector2(0, 0.5f);// const
   
    #endregion

    #region inputmode

    [System.NonSerialized] public int checkMovement = 0;

    #endregion

    private void Awake()
    {
        rigidbody2 = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        switch (checkMovement)
        {
            case 0:

                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
                    }
                }

                else
                {
                    rigidbody2.velocity = Vector3.zero;
                }

                break;

            case 1:

                if (Input.touchCount > 0)
                {
                    touch = Input.GetTouch(0);
                    Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(touch.position);
                    if (touch.phase == TouchPhase.Began)
                    {
                        this.gameObject.transform.position = new Vector3(screenToWorld.x, screenToWorld.y, 0);
                    }
                   
                    if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, touch.deltaPosition + overTouch, lerp * Time.deltaTime); 
                    }
                    else
                    {
                        rigidbody2.velocity = Vector3.zero;
                    }
                }

                break;
        }
       
    }

    public float PlayerSpeed()
    {
        return this.rigidbody2.velocity.magnitude;// return this.speed
    }
}
