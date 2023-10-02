using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public static AudioSettings audioSettings;

    [Header("Information - Read Only from inspector")]
    [SerializeField]
    private float musicVolume;
    [SerializeField]
    private float sfxVolume;

    float musicDefaultVolume=0.7f;
    float sfxDefaultVolume = 0.9f;

    string musicAudioSourcesTag ="Music-AudioSource";
    string sfxAudioSourcesTag="SFX-AudioSource";

    string musicVolumeDataName = "music-volume";
    string sfxVolumeDataName = "sfx-volume";

    List<AudioSource> musicAudioSources;
    List<AudioSource> sfxAudioSources;

    [SerializeField]
    private int musicAudioSourcesCount=0;
    [SerializeField]
    private int sfxAudioSourcesCount = 0;

    private void Awake()
    {
        audioSettings = this;
        musicAudioSources = new List<AudioSource>();
        sfxAudioSources = new List<AudioSource>();
        LoadSavedSettings();
    }

    void LoadSavedSettings()
    {
        musicVolume = PlayerPrefs.GetFloat(musicVolumeDataName,musicDefaultVolume);
        sfxVolume = PlayerPrefs.GetFloat(sfxVolumeDataName, sfxDefaultVolume);

    }

    public void ChangeMusicVolume(float newVolume)
    {
        musicVolume = newVolume;
        PlayerPrefs.SetFloat(musicVolumeDataName, musicVolume);
        SetVolumeToAudioSources(musicAudioSources, musicVolume);
    }


    public void ChangSFXVolume(float newVolume)
    {
        sfxVolume = newVolume;
        PlayerPrefs.SetFloat(sfxVolumeDataName, sfxVolume);
        SetVolumeToAudioSources(sfxAudioSources, sfxVolume);
    }

    void SetVolumeToAudioSources(List<AudioSource> audioSources, float volume)
    {
        foreach (AudioSource a in audioSources)
        {
            a.volume = volume;
        }
    }


    public float GetMusicVolume()
    {
        return musicVolume;
    }
    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public void AddMeToMusicAudioSources(AudioSource a)
    {
        musicAudioSources.Add(a);
        musicAudioSourcesCount = musicAudioSources.Count;
    }

    public void RemoveMeFromMusicAudioSources(AudioSource a)
    {
        musicAudioSources.Remove(a);
        musicAudioSourcesCount = musicAudioSources.Count;
    }
    public void AddMeToSFXAudioSources(AudioSource a)
    {
        sfxAudioSources.Add(a);
        sfxAudioSourcesCount = sfxAudioSources.Count;
    }

    public void RemoveMeFromSFXAudioSources(AudioSource a)
    {
        sfxAudioSources.Remove(a);
        sfxAudioSourcesCount = sfxAudioSources.Count;
    }

    public void StopAllSounds()
{
    StopAllMusic();
    StopAllSFX();
}

public void StopAllMusic()
{
    foreach (AudioSource musicSource in musicAudioSources)
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}

void StopAllSFX()
{
    foreach (AudioSource sfxSource in sfxAudioSources)
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }
    }
}
public void ResumeAllSounds()
{
    ResumeAllMusic();
    ResumeAllSFX();
}

public void ResumeAllMusic()
{
    foreach (AudioSource musicSource in musicAudioSources)
    {
        if (!musicSource.isPlaying)
        {
            musicSource.UnPause();
        }
    }
}

public bool IsMusicPlaying()
{
    foreach (AudioSource musicSource in musicAudioSources)
    {
        if (musicSource.isPlaying)
        {
            return true;
        }
    }
    return false;
}

void ResumeAllSFX()
{
    foreach (AudioSource sfxSource in sfxAudioSources)
    {
        if (!sfxSource.isPlaying)
        {
            sfxSource.UnPause();
        }
    }
}




}
