using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource LevelSong;

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
    private bool fadeOut;

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

        if (fadeIn)
        {

        }
    }

    public void FadeMusic(AudioSource songFadeIn,AudioSource songFadeOut)
    {
        fadeIn = true;
    }

    public void FadeInMusic(AudioClip fadingInSong)
    {
       
    }

    public void FadeOutMusic(AudioClip fadingOutSong)
    {

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
