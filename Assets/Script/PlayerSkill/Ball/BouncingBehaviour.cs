using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float minSpeed;
    [SerializeField]
    private float respawnDistance;
    private Vector3 lastVelocity;
    private Rigidbody2D rigidbody2;
    private bool canRespawnBall = true;

    #region references

    public GameObject ballToRespawn;
    private GameObject gameM;

    #endregion

    private void Awake()
    {
        rigidbody2 = this.gameObject.GetComponent<Rigidbody2D>();
        gameM = GameObject.FindObjectOfType<BallManager>().gameObject;
    }

    private void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("NoCollision");
        StartCoroutine(restartCollision());
        rigidbody2.AddForce(new Vector2(20 * Time.deltaTime * speed, 20 * Time.deltaTime * speed));
    }

    private void Update()
    {
        lastVelocity = rigidbody2.velocity;
        if ((this.transform.position.y) < respawnDistance)
        {
            if(gameM.GetComponent<BallManager>().currentBallLost <= gameM.GetComponent<BallManager>().maxBallToRespawn)
            {
                if (canRespawnBall)
                {
                    CreateNewBall();
                    Destroy(this.gameObject);
                    canRespawnBall = false;
                    gameM.GetComponent<BallManager>().currentBallLost ++;
                }
            }

            else
            {
                Destroy(this.gameObject);
                Debug.Log("YouLose");
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 Dir = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);
        rigidbody2.velocity = Dir * Mathf.Max(speed, minSpeed * Time.deltaTime);
    }

    public void CreateNewBall()
    {
        Instantiate(ballToRespawn, gameM.GetComponent<BallManager>().ballSpawnTransform,ballToRespawn.transform.rotation);
        StartCoroutine(canRespawnBallTime());
    }

    private IEnumerator canRespawnBallTime()
    {
        yield return new WaitForSeconds(1f);
        canRespawnBall = true;
    }

    private IEnumerator restartCollision()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.layer = LayerMask.NameToLayer("NoPlayerCollision");
    }
}
