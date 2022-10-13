using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectibles : MonoBehaviour
{
    private CollectiblesManager collectiblesManager;
    public float value;

    private void Awake()
    {
        collectiblesManager = FindObjectOfType<CollectiblesManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectiblesManager.IncreaseTokenCollectibles(value);;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
