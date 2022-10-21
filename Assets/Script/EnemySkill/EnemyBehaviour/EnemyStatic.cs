using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour,IEnemyBehaviour
{
    [System.NonSerialized] public int HordeCounter = 1;

    public void enemyActiveSelf()
    {
        this.HordeCounter = 0;
    }

    public bool isThisEnemyBehaviourActive()
    {
        throw new System.NotImplementedException();
    }
}
