using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeculareManager : MonoBehaviour
{
    #region prop

    [SerializeField]
    private bool isThisLevelSpeculare;
    [SerializeField]
    private float startingScore;
    [SerializeField]
    private float scoreSubtracted;
    [SerializeField]
    public float timeUploadingScore;

    #endregion

    private GameObject player;
    private GameObject[] enemies;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isThisLevelSpeculare)
        {
            player.AddComponent<SpeculareScore>();
            player.GetComponent<SpeculareScore>().StartScore = this.startingScore;
            player.GetComponent<SpeculareScore>().scoreToSubtract = this.scoreSubtracted;
            player.GetComponent<SpeculareScore>().timeToUploadScore = this.timeUploadingScore;
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].AddComponent<EnemySpeculare>();
            }
        }
    }
}
