using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRewinder : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Vector3 startPos;
    private float boxywidt;

    private void Awake()
    {
        boxywidt = this.GetComponent<BoxCollider2D>().size.x / 2;
    }
  
    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {
        if (transform.position.x < (startPos.x - boxywidt))
        {
            this.transform.position = startPos;
        }
        Debug.Log(startPos.x - boxywidt);
        this.transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
