using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class CollectibleSavedData
{
    private CollectiblesManager collectiblesManager;
    public float collectiblesNumber;
    public float collectiblesRewarded;
    public float maxScoreLV_0;

    #region Saving
    public void Saving()
    {
        CollectibleSavedData data = new CollectibleSavedData();
        collectiblesManager = GameObject.FindObjectOfType<CollectiblesManager>();
        data.collectiblesNumber = collectiblesManager.collectiblesTokenQuantity ; // creare l istanza della classe e cambiare le variabili come vogliamo  ATTENZIONE: non tutte le variabili sono salvabili
        switch (collectiblesManager.currentLevel)
        {
            case 0:
                data.maxScoreLV_0 = collectiblesManager.maxScores[0];
                break;

            case 1:
                break;
        }
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); // salvataggio del codice, cercare di lasciarlo come nel codice originale unity
    }
    #endregion

    #region Loading
    public void Loading()
    {
        string path = Application.persistentDataPath + "/savefile.json";  // legge il file creato in precedenza, cercare di lasciarlo così

        if (File.Exists(path))    // controlla se il file esiste
        {
            string json = File.ReadAllText(path);
            CollectibleSavedData CollectiblesData = JsonUtility.FromJson<CollectibleSavedData>(json); // legge il testo e setta i cambiamenti salvati

            collectiblesNumber = CollectiblesData.collectiblesNumber; // qui noi settiamo la variabile che abbiamo salvato, in quanto nelle righe sopra cambiamo solo il file, non le istanze nel gioco
            maxScoreLV_0 = CollectiblesData.maxScoreLV_0;
        }
    }
    #endregion

    public void SavingRewarded()
    {
        CollectibleSavedData data = new CollectibleSavedData();
        collectiblesManager = GameObject.FindObjectOfType<CollectiblesManager>();
        data.collectiblesRewarded = collectiblesManager.collectiblesRewarded;
        string jsonRewarded = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.jsonRewarded", jsonRewarded);
    }

    public void LoadRewarded()
    {
        string path = Application.persistentDataPath + "/savefile.jsonRewarded"; 

        if (File.Exists(path))    
        {
            string jsonRewarded = File.ReadAllText(path);
            CollectibleSavedData CollectiblesData = JsonUtility.FromJson<CollectibleSavedData>(jsonRewarded); // legge il testo e setta i cambiamenti salvati
            collectiblesRewarded = CollectiblesData.collectiblesRewarded;
          
        }
    }
}
