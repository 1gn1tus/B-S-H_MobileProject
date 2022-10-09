using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    #region ball

    [SerializeField]
    private bool isFlipperLevel;
    [System.NonSerialized]public Vector3 ballSpawnTransform;
    [System.NonSerialized] public int currentBallLost = 0;

    public int maxBallToRespawn ;

    #endregion

    #region references

    [SerializeField]
    private GameObject flipperObject;
    [SerializeField]
    private GameObject shootingSource;

    private GameObject player;
    public GameObject ball;

    #endregion

    private void Awake()
    {
        ball = GameObject.FindObjectOfType<BouncingBehaviour>().gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        if (isFlipperLevel)
        {
            player.GetComponent<AutomateShooting>().enabled = false;
            shootingSource.SetActive(false);
            flipperObject = Instantiate(flipperObject, player.transform.position, flipperObject.transform.rotation, player.transform);
            flipperObject.transform.position = new Vector3(flipperObject.transform.position.x, flipperObject.transform.position.y + 2f, 0);
            ball.GetComponent<BouncingBehaviour>().enabled = true;
            ballSpawnTransform = ball.transform.position;
        }
    }

    private void Update()
    {
       flipperObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, 0);
    }
}
