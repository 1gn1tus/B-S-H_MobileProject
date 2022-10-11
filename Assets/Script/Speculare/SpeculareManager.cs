using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeculareManager : MonoBehaviour
{
    [SerializeField]
    private bool isThisLevelSpeculare;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isThisLevelSpeculare)
        {
            player.AddComponent<SpeculareScore>();
        }
    }
}
