using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourInHorde : MonoBehaviour
{
    [SerializeField]
    private Vector3 StartingPos;
    [SerializeField]
    private float TimeToStartBehaviour;

    public void ChoosePosition()
    {
        this.transform.position = StartingPos;
    }

    public void EnableBehaviour()
    {
        StartCoroutine(TimeToEnableBehaviour());
    }

    private IEnumerator TimeToEnableBehaviour()
    {
        yield return new WaitForSeconds(TimeToStartBehaviour);
        this.gameObject.GetComponent<IEnemyBehaviour>().isThisEnemyBehaviourActive();
    }
}
