using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBehaviour
{
    public bool isThisEnemyBehaviourActive();
    public void enemyActiveSelf();
}
