using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamage
{
    [SerializeField]
    private float OnCollDamage;
    [SerializeField]
    private float invincibleFramesDuration;
    public float playerHp;
    [System.NonSerialized] public bool isHitten;
    [System.NonSerialized] public bool OstageisRunningAway;

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
        InvincibilityFrames();
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
