using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource LevelSong;
    public AudioSource LevelSong_ToFadeIn;

    #region audiomixer

    public float masterVolumeFloat;
    public float SFXVolumeFloat;
    public float AmbientalVolumeFloat;

    public AudioMixer MasterVolume;
    public AudioMixer SFXVolume;
    public AudioMixer AmbientalSound;
    #endregion

    #region fading

    private bool fadeIn;
    public bool FadingTransition;

    #endregion

    private void Start()
    {
        SaveAudioSetting saveAudioSetting = new SaveAudioSetting();
        saveAudioSetting.Loading();
        masterVolumeFloat = saveAudioSetting.MasterVolume;
        SFXVolumeFloat = saveAudioSetting.SFXVolume;
        AmbientalVolumeFloat = saveAudioSetting.AmbientalVolume;
        LevelSong.Play();
    }

    private void Update()
    {
        /*
        SaveAudioSetting saveAudioSetting = new SaveAudioSetting();
        saveAudioSetting.Saving();*/

        if (FadingTransition)
        {
            FadeMusic(LevelSong_ToFadeIn,this.LevelSong);
        }
    }

    public void FadeMusic(AudioSource fadingInSong, AudioSource fadingOutSong)
    {
        if (!fadeIn)
        {
            fadingInSong.volume = 0;
            fadingOutSong.volume -= Time.deltaTime;

            if (fadingOutSong.volume <= 0)
            {
                fadeIn = true;
                fadingOutSong.Stop();
            }
        }

        else
        {
            fadingInSong.Play();
            fadingInSong.volume += Time.deltaTime;

            if (fadingInSong.volume >= 1)
            {
                fadeIn = false;
                FadingTransition = false;
            }
        }    
    }

    public void MasterVolumeSetFloatFunction()
    {
        MasterVolume.SetFloat("MasterVolume", masterVolumeFloat);
    }

    public void SFXVolumeSetFloatFunction()
    {
        SFXVolume.SetFloat("SFXVolume", SFXVolumeFloat);
    }

    public void AmbientalSoundSetFloatFunction()
    {
        AmbientalSound.SetFloat("AmbientalVolume", AmbientalVolumeFloat);
    }
}
