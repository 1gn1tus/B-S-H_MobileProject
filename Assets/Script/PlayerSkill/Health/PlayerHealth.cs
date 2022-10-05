using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamage
{
    public float playerHp;
    [System.NonSerialized] public bool isHitten;
    [System.NonSerialized] public bool OstageisRunningAway;

    #region test
    public bool test;

    private void Update()
    {
        if (test)
        {
            ITakeDamage(1);
            test = false;
        }
    }
    #endregion

    public void ITakeDamage(float damage)
    {
        this.playerHp = this.playerHp - damage;
        this.isHitten = true;
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
}
