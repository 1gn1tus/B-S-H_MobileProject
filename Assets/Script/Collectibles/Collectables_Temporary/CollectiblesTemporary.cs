using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollectiblesTemporary : MonoBehaviour
{
    public float collectibleValue;

    private CollectiblesManager collectiblesManager;

    private void Awake()
    {
        collectiblesManager = GameObject.FindObjectOfType<CollectiblesManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectiblesManager.IncreaseCollectiblesTemporary(this.collectibleValue);
            collectiblesManager.GetCollectiblesReward();
            Destroy(this.gameObject);
        }
    }
}
