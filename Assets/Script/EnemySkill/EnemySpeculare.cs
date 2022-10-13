using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeculare : MonoBehaviour
{
    private GameObject player;

    private EnemyHealth enemyHealth;

    private bool doOnce = true;

    private void Awake()
    {
        enemyHealth = this.gameObject.GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectiles>())
        {
            player.GetComponent<SpeculareScore>().StopScore();
            if (doOnce)
            {

                StartCoroutine(RestartCounterScore());
                doOnce = false;
            }
        }
    }

    private IEnumerator RestartCounterScore()
    {
        yield return new WaitForSeconds(enemyHealth.enemyStopScore);
        StartCoroutine(player.GetComponent<SpeculareScore>().ScoreUpdates());
        doOnce = true;
    }
}
