using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveAudioSetting
{
    private SoundManager soundM;

    public float MasterVolume;
    public float SFXVolume;
    public float AmbientalVolume;

    #region Saving

    public void Saving()
    {
        SaveAudioSetting Soundata = new SaveAudioSetting();
        soundM = GameObject.FindObjectOfType<SoundManager>();
        Soundata.MasterVolume = soundM.masterVolumeFloat; // ATTENZIONE: non tutte le variabili sono salvabili
        Soundata.SFXVolume = soundM.SFXVolumeFloat;
        Soundata.AmbientalVolume = soundM.AmbientalVolumeFloat;
        string jsonSoundData = JsonUtility.ToJson(Soundata);
        File.WriteAllText(Application.persistentDataPath + "/savefile.jsonSoundData", jsonSoundData); 
    }
    #endregion

    #region Loading
    public void Loading()
    {
        string path = Application.persistentDataPath + "/savefile.jsonSoundData";  // legge il file creato in precedenza, cercare di lasciarlo così

        if (File.Exists(path))
        {
            string SoundData = File.ReadAllText(path);
            SaveAudioSetting audioData = JsonUtility.FromJson<SaveAudioSetting>(SoundData); // legge il testo e setta i cambiamenti salvati
            MasterVolume = audioData.MasterVolume;
            SFXVolume = audioData.SFXVolume;
            AmbientalVolume = audioData.AmbientalVolume;
        }
    }
    #endregion

}
