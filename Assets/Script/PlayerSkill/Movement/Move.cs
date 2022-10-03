using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour,IinputProvider
{
    private Touch touch;
    private Rigidbody2D rigidbody2;
    private const float lerp = 0.7355f;
    [System.NonSerialized] public float speedMagnitude;

    private void Awake()
    {
        rigidbody2 = this.gameObject.GetComponent<Rigidbody2D>();
        speedMagnitude = PlayerSpeed();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
           touch = Input.GetTouch(0);
           if(touch.phase == TouchPhase.Moved)
           {
                this.gameObject.transform.position = Vector3.Lerp(this.transform.position, touch.deltaPosition, lerp * Time.deltaTime); //new Vector3(transform.position.x + touch.deltaPosition.x * speed * Time.deltaTime, transform.position.y + touch.deltaPosition.y * speed * Time.deltaTime, 0);
           }
        }

        else
        {
            rigidbody2.velocity = Vector3.zero;
        }
    }

    public float PlayerSpeed()
    {
        return this.rigidbody2.velocity.magnitude;// return this.speed
    }
}
