using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeculareScore : MonoBehaviour
{
    public float StartScore;
    [System.NonSerialized]
    public float scoreToSubtract;
    [System.NonSerialized]
    public float timeToUploadScore;

    private void Start()
    {
        StartCoroutine(ScoreUpdates());
    }

    public IEnumerator ScoreUpdates()
    {
        yield return new WaitForSeconds(timeToUploadScore);
        this.StartScore = this.StartScore - scoreToSubtract;
        StartCoroutine(ScoreUpdates());
    }

    public void StopScore()
    {
        StopAllCoroutines();
    }
}
