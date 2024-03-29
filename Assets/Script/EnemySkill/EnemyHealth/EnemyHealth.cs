using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamage
{
    [SerializeField]
    public float Hp;
    public float enemyStopScore = 3f;
    private bool DoOnce = true;
    #region horde

    [System.NonSerialized] public int HordeCounter = 1;
    private GameObject gameM;
    private AchievementsManager achievementsManager;

    #endregion

    private void Awake()
    {
        achievementsManager = GameObject.FindObjectOfType<AchievementsManager>();
        gameM = GameObject.FindObjectOfType<EnemyHordeBehaviour>().gameObject;
    }

    public void ITakeDamage(float damage)
    {
        this.Hp = this.Hp - damage;
    }

    private void Update()
    {
        if(this.Hp <= 0)
        {
            if (DoOnce)
            {
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameM.GetComponent<EnemyHordeBehaviour>().UploadHordeEnemyCounter(HordeCounter);
                // achievementsManager.EnemyDefeated++;
                this.gameObject.GetComponent<IEnemyBehaviour>().enemyActiveSelf();
                DoOnce = false;
            }
            
        }
    }
}
