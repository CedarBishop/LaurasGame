using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    public static event System.Action OnVolumeChange;
    public AudioClip buttonSFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySFX(AudioClip newClip)
    {
        sfxAudioSource.clip = newClip;
        sfxAudioSource.Play();
    }

    public void RaiseSFXVolume ()
    {
        sfxAudioSource.volume += 0.1f;
        AudioManager.instance.PlaySFX(buttonSFX);


        if (sfxAudioSource.volume > 1)
        {
            sfxAudioSource.volume = 1;
        }
        if (OnVolumeChange != null)
        {
            OnVolumeChange();
        }
    }

    public void RaiseBGMVolume ()
    {
        bgmAudioSource.volume += 0.1f;
        AudioManager.instance.PlaySFX(buttonSFX);


        if (bgmAudioSource .volume > 1)
        {
            bgmAudioSource.volume = 1;
        }
        if (OnVolumeChange != null)
        {
            OnVolumeChange();
        }
    }

    public void LowerSFXVolume()
    {
        sfxAudioSource.volume -= 0.1f;
        AudioManager.instance.PlaySFX(buttonSFX);

        if (sfxAudioSource.volume < 0)
        {
            sfxAudioSource.volume = 0;
        }
        if (OnVolumeChange != null)
        {
            OnVolumeChange();
        }
    }

    public void LowerBGMVolume()
    {
        bgmAudioSource.volume -= 0.1f;
        AudioManager.instance.PlaySFX(buttonSFX);

        if (bgmAudioSource.volume < 0)
        {
            bgmAudioSource.volume = 0;
        }
        if (OnVolumeChange != null)
        {
            OnVolumeChange();
        }
    }
}
