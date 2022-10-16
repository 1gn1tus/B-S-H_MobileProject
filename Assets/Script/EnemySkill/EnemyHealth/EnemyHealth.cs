using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamage
{
    [SerializeField]
    public float Hp;
    public float enemyStopScore = 3f;

    #region horde

    [System.NonSerialized] public int HordeCounter = 1;
    private GameObject gameM;

    #endregion

    private void Awake()
    {
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
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameM.GetComponent<EnemyHordeBehaviour>().UploadHordeEnemyCounter(HordeCounter);
            this.gameObject.GetComponent<IEnemyBehaviour>().enemyActiveSelf();
        }
    }
}
