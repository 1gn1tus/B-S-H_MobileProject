using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvulnerable : MonoBehaviour,IDamage
{
    [SerializeField]
    public float InvulnerabilityobjectHp;
    [SerializeField]
    private GameObject invulnerableEnemy;
    [SerializeField]
    private float InvulnerabilityrotationSpeed;
    [SerializeField]
    private GameObject enemyBarrierGameObject;
    [SerializeField]
    private float enemyBarrierSize;
    [SerializeField]
    private float damageOnCollision;

    private Projectiles projectiles;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        invulnerableEnemy.layer = LayerMask.NameToLayer("NoCollision");
        this.transform.parent = invulnerableEnemy.transform;
        enemyBarrierGameObject = Instantiate(enemyBarrierGameObject, invulnerableEnemy.transform.position, enemyBarrierGameObject.transform.rotation, invulnerableEnemy.transform);
        enemyBarrierGameObject.transform.localScale = new Vector3(enemyBarrierSize, enemyBarrierSize, 0);
    }

    private void Update()
    {
        this.transform.RotateAround(invulnerableEnemy.transform.position, Vector3.forward, InvulnerabilityrotationSpeed * Time.deltaTime);

        if (this.InvulnerabilityobjectHp <= 0)
        {
            invulnerableEnemy.layer = LayerMask.NameToLayer("Enemy");
            Destroy(this.gameObject);
            Destroy(enemyBarrierGameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectiles>())
        {
            projectiles = collision.gameObject.GetComponent<Projectiles>();
            ITakeDamage(projectiles.damageToEnemy);
            Destroy(projectiles.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerHealth>().ITakeDamage(damageOnCollision);
        }
    }

    public void ITakeDamage(float damage)
    {
        this.InvulnerabilityobjectHp -= damage;
    }
}
