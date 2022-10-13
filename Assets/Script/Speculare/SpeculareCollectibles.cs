using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpeculareCollectibles : MonoBehaviour
{
    public float collectibleValue = 1;

    private CollectiblesManager collectiblesManager;

    private void Awake()
    {
        collectiblesManager = GameObject.FindObjectOfType<CollectiblesManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectiblesManager.DecreaseCollectiblesTemporary(this.collectibleValue);
            collectiblesManager.GetCollectiblesReward();
            Destroy(this.gameObject);
        }
    }
}
