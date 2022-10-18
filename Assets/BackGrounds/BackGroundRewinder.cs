using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRewinder : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private float RepetDistance;
    private Vector3 startPos;
    
    void Start()
    {
        startPos = this.transform.position;
        Debug.Log(startPos.x - RepetDistance);
    }

    void Update()
    {
        if (this.transform.position.y < (startPos.x - RepetDistance))
        {
            this.transform.position = startPos;
        }

        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
    }
}
