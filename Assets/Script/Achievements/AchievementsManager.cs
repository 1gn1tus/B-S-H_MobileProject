using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    [System.NonSerialized]public int EnemyDefeated;
    public int EnemyDefeatedAchievement;
    public bool AchievementEnemyFirstTime;

    private void Start()
    {
        AchievementsSaveData achievementsSaveData = new AchievementsSaveData();
        achievementsSaveData.Loading();
        EnemyDefeated = achievementsSaveData.EnemyDefeatedValue;
        AchievementEnemyFirstTime = achievementsSaveData.AchievementEnemyFirstTime;
    }

    private void Update()
    {
        if (AchievementEnemyFirstTime == false)
        {
            if (EnemyDefeated >= EnemyDefeatedAchievement)
            {
                Debug.Log("CongratToDefeatEnemy");
                AchievementEnemyFirstTime = true;

                AchievementsSaveData achievementsSaveData = new AchievementsSaveData();
                achievementsSaveData.Saving();
            }
        }
    }
}
