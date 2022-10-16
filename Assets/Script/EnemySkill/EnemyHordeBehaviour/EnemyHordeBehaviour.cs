using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHordes))]
public class EnemyHordeBehaviour : MonoBehaviour
{
    #region getHorde
    public float maxHordes;
    private float currentHordeInt = 0;
    private List<GameObject> currentHorde;
    private bool newHorde = true;
    private int enemyDefeatedInCurrentHorde = 0;
    private int enemyInCurrentHorde;

    #endregion

    EnemyHordes enemyHordes;

    private void Awake()
    {
        enemyHordes = this.gameObject.GetComponent<EnemyHordes>();
    }
    private void Update()
    {
        if(currentHordeInt < maxHordes)
        {
            if (enemyDefeatedInCurrentHorde == enemyInCurrentHorde)
            {
                enemyDefeatedInCurrentHorde = 0;
                newHorde = true;
            }

            if (newHorde)
            {
                currentHorde = enemyHordes.GetHorde();
                enemyInCurrentHorde = currentHorde.Count;
                ActivateHorde();
                currentHordeInt++;
                newHorde = false;
            }
        }
    }

    public void UploadHordeEnemyCounter(int upload)
    {
        this.enemyDefeatedInCurrentHorde += upload;
    }

    public void ActivateHorde()
    {
        for(int i = 0; i < enemyInCurrentHorde; i++)
        {
            currentHorde[i].GetComponent<EnemyBehaviourInHorde>().ChoosePosition();
            currentHorde[i].GetComponent<EnemyBehaviourInHorde>().EnableBehaviour();
        }
    }
}
