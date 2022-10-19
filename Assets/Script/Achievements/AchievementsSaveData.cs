using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class AchievementsSaveData
{
    public int EnemyDefeatedValue;
    public bool AchievementEnemyFirstTime;
    private AchievementsManager achievementsManager;
    #region Saving
    public void Saving()
    {
        AchievementsSaveData data = new AchievementsSaveData();
        achievementsManager = GameObject.FindObjectOfType<AchievementsManager>();
        data.EnemyDefeatedValue = achievementsManager.EnemyDefeated; // creare l istanza della classe e cambiare le variabili come vogliamo  ATTENZIONE: non tutte le variabili sono salvabili
        data.AchievementEnemyFirstTime = achievementsManager.AchievementEnemyFirstTime;
        string jsonAchievements = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.jsonAchievements", jsonAchievements); // salvataggio del codice, cercare di lasciarlo come nel codice originale unity
    }
    #endregion

    #region Loading
    public void Loading()
    {
        string path = Application.persistentDataPath + "/savefile.jsonAchievements";  // legge il file creato in precedenza, cercare di lasciarlo così

        if (File.Exists(path))    // controlla se il file esiste
        {
            string jsonAchievements = File.ReadAllText(path);
            AchievementsSaveData achievementsData = JsonUtility.FromJson<AchievementsSaveData>(jsonAchievements); // legge il testo e setta i cambiamenti salvati

            AchievementEnemyFirstTime = achievementsData.AchievementEnemyFirstTime;
            EnemyDefeatedValue = achievementsData.EnemyDefeatedValue; // qui noi settiamo la variabile che abbiamo salvato, in quanto nelle righe sopra cambiamo solo il file, non le istanze nel gioco
        }
    }
    #endregion
}
