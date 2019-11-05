using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AudioType { BGM,SFX}
[RequireComponent(typeof(Image))]
public class AudioFillImage : MonoBehaviour
{
    public AudioType audioType;
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        AudioManager.OnVolumeChange += UpdateFillImage;
        UpdateFillImage();
    }

    private void OnDestroy()
    {
        AudioManager.OnVolumeChange -= UpdateFillImage; 
    }

    private void UpdateFillImage()
    {
        switch (audioType)
        {
            case AudioType.BGM:
                image.fillAmount = AudioManager.instance.bgmAudioSource.volume;
                break;
            case AudioType.SFX:
                image.fillAmount = AudioManager.instance.sfxAudioSource.volume;
                break;
            default:
                break;
        }
    }
}