using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeculareManager : MonoBehaviour
{
    #region prop

    [SerializeField]
    private float startingScore;
    [SerializeField]
    private float scoreSubtracted;
    [SerializeField]
    public float timeUploadingScore;

    public bool isThisLevelSpeculare;

    #endregion

    #region ref

    private GameObject player;
    private GameObject[] enemies;
    private CollectiblesTemporary[] SpeculareCollectiblesChanging;

    #endregion

    #region speedTouch speculare

    [SerializeField]
    private float speedTouchSpeculare = 10;
    [SerializeField]
    private float speedJoystickSpeculare = 5;
    [SerializeField]
    private float ScreenYmax = 3;

    #endregion


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        SpeculareCollectiblesChanging = GameObject.FindObjectsOfType<CollectiblesTemporary>();
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
            player.GetComponent<Move>().enabled = false;
            player.AddComponent<SpeculareMove>();
            player.GetComponent<SpeculareMove>().TouchspeedSpeculare = speedTouchSpeculare;
            player.GetComponent<SpeculareMove>().JoystickSpeed = speedJoystickSpeculare;
            player.GetComponent<SpeculareMove>().screenMaxHeight = ScreenYmax;
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].AddComponent<EnemySpeculare>();
            }

            for (int i = 0; i < SpeculareCollectiblesChanging.Length; i++)
            {
                SpeculareCollectiblesChanging[i].gameObject.AddComponent<SpeculareCollectibles>();
                SpeculareCollectiblesChanging[i].GetComponent<SpeculareCollectibles>().collectibleValue = SpeculareCollectiblesChanging[i].GetComponent<CollectiblesTemporary>().collectibleValue;
                Destroy(SpeculareCollectiblesChanging[i].GetComponent<CollectiblesTemporary>());
                Destroy(SpeculareCollectiblesChanging[i].GetComponent<Collectibles>());
            }
        }
    }
}
