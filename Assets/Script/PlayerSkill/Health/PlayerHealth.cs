using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using FirstGearGames.SmoothCameraShaker;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamage
{
    private bool doOnce = true;
    [SerializeField]
    private float OnCollDamage;
    [SerializeField]
    private float invincibleFramesDuration;
    [SerializeField]
    private GameObject gameOverPanel;
    public float playerHp;
    [System.NonSerialized] public string currentLevel;
    [System.NonSerialized] public bool isHitten;
    [System.NonSerialized] public bool OstageisRunningAway;

    #region feedbackOnHit

    public ShakeData MyShake;
    public float timeToRestartMoving;

    #endregion

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(this.playerHp <= 0)
        {
            if (doOnce)
            {
                Instantiate(gameOverPanel,Vector3.zero,gameOverPanel.transform.rotation);
                doOnce = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Obstacle") || collision.CompareTag("Boss"))
        {
            ITakeDamage(OnCollDamage);
        }
    }

    public void ITakeDamage(float damage)
    {
        this.playerHp = this.playerHp - damage;
        this.isHitten = true;
        CameraShakerHandler.Shake(MyShake);
        StopOnHit();
        InvincibilityFrames();
    }

    public void StopOnHit()
    {
        this.gameObject.GetComponent<Move>().enabled = false;
        StartCoroutine(restartMove());
    }

    private IEnumerator restartMove()
    {
        yield return new WaitForSeconds(timeToRestartMoving);
        this.gameObject.GetComponent<Move>().enabled = true;
    }

    public bool MakeOstagesRun()
    {
        if (this.isHitten)
        {
            this.OstageisRunningAway = true;
            return this.OstageisRunningAway;
        }
        else
        {
            return false;
        }
    }
    public void InvincibilityFrames()
    {
        this.gameObject.layer = LayerMask.NameToLayer("InvincibilityFrames");
        StartCoroutine(invincibilityFramesTime());
    }

    private IEnumerator invincibilityFramesTime()
    {
        yield return new WaitForSeconds(invincibleFramesDuration);
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
