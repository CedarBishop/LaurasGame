﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject gameMenuParent;
    public GameObject onPurposePauseMenuParent;
    public GameObject resetPauseMenuParent;

    public string mainMenuName = "TitleScreen";

    public AudioClip buttonSFX;
    void Start()
    {
        StartResetPause();
        Timer.FailedLetter += StartResetPause;
    }

    private void OnDestroy()
    {
        Timer.FailedLetter -= StartResetPause;
    }

    public void StartResetPause ()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        Time.timeScale = 0;
        gameMenuParent.gameObject.SetActive(false);
        onPurposePauseMenuParent.gameObject.SetActive(false);
        resetPauseMenuParent.gameObject.SetActive(true);
    }

    public void OnPurposePause ()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        Time.timeScale = 0;
        gameMenuParent.gameObject.SetActive(false);
        onPurposePauseMenuParent.gameObject.SetActive(true);
        resetPauseMenuParent.gameObject.SetActive(false);
    }

    public void Play()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        Time.timeScale = 1;
        gameMenuParent.gameObject.SetActive(true);
        onPurposePauseMenuParent.gameObject.SetActive(false);
        resetPauseMenuParent.gameObject.SetActive(false);
    }

    public void MainMenu ()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        SceneManager.LoadScene(mainMenuName);
    }
}
