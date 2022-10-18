using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesManager : MonoBehaviour,IScore
{
    #region score

    [System.NonSerialized] public float[] maxScores = new float[2];// fixed number of levels
    [System.NonSerialized]public float TemporaryCollectiblesNumber;

    #endregion

    #region score = reward

    [SerializeField] private float ScoreConversion;
    [System.NonSerialized] public float collectiblesRewarded;

    #endregion

    public int currentLevel;

    [System.NonSerialized] public float collectiblesTokenQuantity;

    private void Awake()
    {
        SavedData CollectiblesData = new SavedData();
        CollectiblesData.Loading();
        CollectiblesData.LoadRewarded();
        collectiblesTokenQuantity = CollectiblesData.collectiblesNumber;
        collectiblesRewarded = CollectiblesData.collectiblesRewarded;
        maxScores[0] = CollectiblesData.maxScoreLV_0;
        Debug.Log(collectiblesTokenQuantity);
        Debug.Log(collectiblesRewarded);
        Debug.Log(maxScores[0]);
    }

    public float IncreaseTokenCollectibles(float collectableValue)
    {
        this.collectiblesTokenQuantity += collectableValue;
        SavedData CollectiblesData = new SavedData();
        CollectiblesData.Saving();
        return this.collectiblesTokenQuantity;
    }

    public float DecreaseTokenCollectibles(float collectableValue)
    {
        this.collectiblesTokenQuantity -= collectableValue;
        SavedData CollectiblesData = new SavedData();
        CollectiblesData.Saving();
        return this.collectiblesTokenQuantity;
    }

    public void IncreaseCollectiblesTemporary(float collectibleValue)
    {
        this.TemporaryCollectiblesNumber += collectibleValue;
    }

    public void DecreaseCollectiblesTemporary(float collectibleValue)
    {
        this.TemporaryCollectiblesNumber -= collectibleValue;
    }

    public void CheckMaxScore(int level)
    {
        level = this.currentLevel;
        switch (level)
        {
            case 0:
                if(TemporaryCollectiblesNumber > maxScores[0])
                {
                    maxScores[0] = TemporaryCollectiblesNumber;
                    SavedData CollectiblesData = new SavedData();
                    CollectiblesData.Saving();
                }
                break;

            case 1:
                Debug.Log("level_1");
                break;
        }
           
    }

    public float CurrentScoreLevel()
    {
        return this.TemporaryCollectiblesNumber;
    }

    public float GetCollectiblesReward()
    {
        this.collectiblesRewarded = this.collectiblesRewarded + (TemporaryCollectiblesNumber * ScoreConversion);
        SavedData CollectiblesData = new SavedData();
        CollectiblesData.SavingRewarded();
        return this.collectiblesRewarded;
    }
}
