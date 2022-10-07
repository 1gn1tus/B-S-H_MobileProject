using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField]
    private bool isThisAColorLevel;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        if (this.isThisAColorLevel)
        {
            player.AddComponent(typeof(ColorChange));
        } 
    }
}
