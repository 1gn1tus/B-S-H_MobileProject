using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInputReceiver : MonoBehaviour, IinputProvider
{
    public float speed;

    public Vector2 Direction(Vector2 dir)
    {
        dir = dir * speed * Time.deltaTime;
        return dir;
    }
}
