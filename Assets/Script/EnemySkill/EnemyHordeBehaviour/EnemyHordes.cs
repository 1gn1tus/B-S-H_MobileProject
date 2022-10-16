using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHordes : MonoBehaviour
{
    #region enemyLine

    private DIrectLineWIthShoot[] dIrectLineWIthShoots;
    private int currentEnemyLine = 0;

    public int[] quantityOfEnemyLinePerHorde;

    #endregion

    private int HordeCounter = 0;

    void Start()
    {
        dIrectLineWIthShoots = GameObject.FindObjectsOfType<DIrectLineWIthShoot>();
    }

    public List <GameObject> GetHorde()
    {
        List<GameObject> hordes = new List<GameObject>();

        for(int i = 0; i < quantityOfEnemyLinePerHorde[HordeCounter]; i++)
        {
            GameObject gameObjectToAdd;
            gameObjectToAdd = GetDirectLineWithShoot();
            hordes.Add(gameObjectToAdd);
        }
        HordeCounter++;
        return hordes;
    }

    public GameObject GetDirectLineWithShoot()
    {
        GameObject gotDirectLine = dIrectLineWIthShoots[currentEnemyLine].gameObject;

        if(dIrectLineWIthShoots[currentEnemyLine].gameObject != null)
        {
            currentEnemyLine++;
            return gotDirectLine;
        }

        else
        {
            Debug.Log("enemy doesn't exist");     // contare bene se si sono messi i numeri giusti nei nemici
        }

        return default;
    }
}
