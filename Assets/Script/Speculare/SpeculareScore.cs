using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeculareScore : MonoBehaviour
{
    [SerializeField]
    private float scoreToSubtract;
    [SerializeField]
    private float timeToUploadScore;
    [SerializeField]
    private float StartScore;

    public bool StopScore;

    private void Update()
    {
        if(StopScore == true)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator ScoreUpdates()
    {
        yield return new WaitForSeconds(timeToUploadScore);
        this.StartScore -= scoreToSubtract;
    }

    public void RestartScore()
    {
        this.StopScore = false;
    }
}
