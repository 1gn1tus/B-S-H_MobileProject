using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    #region Projectiles Properties

    private AutomateShooting automateShooting;

    public float timeToDestroyProjectile; // upgradable

    #endregion

    #region Damage

    private EnemyHealth enemyHealth;

    public float damageToEnemy;

    #endregion

    private void Start()
    {
        automateShooting = GameObject.FindObjectOfType<AutomateShooting>();
        Destroy(this.gameObject, timeToDestroyProjectile);
    }

    void Update()
    {
        this.transform.position = this.transform.position + Vector3.up * Time.deltaTime * automateShooting.ProjectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            enemyHealth = collision.GetComponent<EnemyHealth>();
            enemyHealth.ITakeDamage(damageToEnemy);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
