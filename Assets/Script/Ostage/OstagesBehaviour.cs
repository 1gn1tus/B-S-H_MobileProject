using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OstagesBehaviour : MonoBehaviour,IOstagePointsRun
{
    #region pointsRun

    [SerializeField]
    private Vector3[] RunAwayPoints;
    [SerializeField]
    private float maxTimeToSaveOstage;
    [SerializeField]
    private float ostagesRunAwaySpeed;
    [SerializeField]
    private float ostagesFollowSpeed;
    private float treesholdPointRun = 0.5f;
    private bool MustRunAway;
    private bool canChangePath = true;
    private int randomPointRun;
    private int lastRandomPointRun;
    private bool HasfirstRunPoint = false;
    private Vector3 pointRunToReach;

    #endregion

    #region Saved

    private bool isSaved;
    private bool canFollowPlayer = false;
    private float offSetOstage = 1.5f;
    private GameObject player;

    #endregion

    private PlayerHealth playerHp;
    private ScreenOrientedInGame screenOrientedInGame;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHp = GameObject.FindObjectOfType<PlayerHealth>();
        screenOrientedInGame = GameObject.FindObjectOfType<ScreenOrientedInGame>();
    }

    private void Update()
    {
        this.MustRunAway = playerHp.MakeOstagesRun();
        OstageEscapeWhenPlayerHit();
        FollowPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.isSaved = true;
            StopAllCoroutines();
            playerHp.isHitten = false;
            canFollowPlayer = true;
            HasfirstRunPoint = false;
        }
    }

    private Vector3 GetRandomPointRun()
    {
        this.randomPointRun = Random.Range(0, RunAwayPoints.Length);
        if(randomPointRun != lastRandomPointRun)
        {
            this.pointRunToReach = RunAwayPoints[randomPointRun];
            this.lastRandomPointRun = randomPointRun;
            return this.pointRunToReach;
        }
        else
        {
            GetRandomPointRun();
        }

        return default;
    }

    private void OstageRunDirection()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, pointRunToReach,ostagesRunAwaySpeed * Time.deltaTime);

    }

    private void OstagePath()
    {
        OstageRunDirection();
        
        if ((pointRunToReach.magnitude - this.gameObject.transform.position.magnitude) < treesholdPointRun)
        {
            if (canChangePath)
            {
                GetRandomPointRun();
                canChangePath = false;
                StartCoroutine(ChangePathRunPoints());
            }   
        }
    }

    private void OstageEscapeWhenPlayerHit()
    {
        if (isSaved)
        {
            if (MustRunAway)
            {
                if (!HasfirstRunPoint)
                {
                    GetRandomPointRun();
                    OstagePath();
                    HasfirstRunPoint = true;
                    canFollowPlayer = false;
                }
                else
                {
                    StartCoroutine(OstageGone());
                    OstagePath();
                }
            }
        }
    }

    public void FollowPlayer()
    {
        if (canFollowPlayer)
        {
            if(screenOrientedInGame.isOrizzontalOriented == false)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x, player.transform.position.y - offSetOstage, 0), ostagesFollowSpeed * Time.deltaTime);
            }

            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x - offSetOstage, player.transform.position.y, 0), ostagesFollowSpeed * Time.deltaTime);
            }
        }
    }

    public IEnumerator OstageGone()
    {
        yield return new WaitForSeconds(maxTimeToSaveOstage);
        playerHp.isHitten = false;
        Destroy(this.gameObject);
    }

    private IEnumerator ChangePathRunPoints()
    {
        yield return new WaitForSeconds(0.5f);
        canChangePath = true;

    }

    public Vector2 PointRun_0()
    {
        return this.RunAwayPoints[0];
    }

    public Vector2 PointRun_1()
    {
        return this.RunAwayPoints[1];
    }

    public Vector2 PointRun_2()
    {
        return this.RunAwayPoints[2];
    }

    public Vector2 PointRun_3()
    {
        return this.RunAwayPoints[3];
    }
}
