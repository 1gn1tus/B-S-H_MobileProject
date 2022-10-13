using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] TypeOfenemiesToSpawn;
    [SerializeField]
    private float[] QuantityOfEnemyForType;
    [SerializeField]
    private GameObject enemyContainer;
    // Start is called before the first frame update
    void Start()
    {
        for(int a = 0; a < TypeOfenemiesToSpawn.Length; a++)
        {
            for (int i = 0; i < QuantityOfEnemyForType[a]; i++)
            {
               GameObject newEnemy = Instantiate(TypeOfenemiesToSpawn[i], enemyContainer.transform.position , this.transform.rotation, enemyContainer.transform);
                newEnemy.layer = LayerMask.NameToLayer("NoCollision");
            }
        }
    }
}
