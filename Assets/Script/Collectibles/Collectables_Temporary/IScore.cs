using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScore 
{
    public void CheckMaxScore(int level);
    public float CurrentScoreLevel();
}
