﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string easyMode = "GameScene";
    public string mediumMode = "mediumScene";
    public string hardMode = "hardScene";
    public GameObject mainMenuParent;
    public GameObject settingsMenuParent;
    public GameObject difficultySelectParent;
    public AudioClip buttonSFX;


    Color currentColor = Color.magenta;
    Color newTargetColor;
    public float colorChangeSpeed = 1;
    public Text[] allText;

    

    private void Start()
    {
        Time.timeScale = 1;
        mainMenuParent.gameObject.SetActive(true);
        settingsMenuParent.gameObject.SetActive(false);
        difficultySelectParent.gameObject.SetActive(false);
        StartCoroutine("ChangeTargetColor");
    }

    private void Update()
    {
        currentColor = Color.Lerp(currentColor, newTargetColor, colorChangeSpeed * Time.deltaTime);
        for (int i = 0; i < allText.Length; i++)
        {
            allText[i].color = currentColor;
        }
    }

    public void LevelSelect ()
    {
        mainMenuParent.gameObject.SetActive(false);
        settingsMenuParent.gameObject.SetActive(false);
        difficultySelectParent.gameObject.SetActive(true);
        AudioManager.instance.PlaySFX(buttonSFX);
    }

    public void TransistionToSettings ()
    {
        mainMenuParent.gameObject.SetActive(false);
        settingsMenuParent.gameObject.SetActive(true);
        difficultySelectParent.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(buttonSFX);

    }

    public void TransistionToMainMenu ()
    {
        mainMenuParent.gameObject.SetActive(true);
        settingsMenuParent.gameObject.SetActive(false);
        difficultySelectParent.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(buttonSFX);

    }

    public void QuitGame ()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        Application.Quit();
    }

    public void PlayEasyMode()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        SceneManager.LoadScene(easyMode);
    }

    public void PlayMediumMode()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        SceneManager.LoadScene(mediumMode);
    }

    public void PlayHardMode ()
    {
        AudioManager.instance.PlaySFX(buttonSFX);

        SceneManager.LoadScene(hardMode);
    }

    IEnumerator ChangeTargetColor()
    {
        while (true)
        {
            newTargetColor = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f), 1);
            yield return new WaitForSeconds(1);
        }
    }

    public void RaiseSFXVolume()
    {
        AudioManager.instance.RaiseSFXVolume();
    }

    public void RaiseBGMVolume()
    {
        AudioManager.instance.RaiseBGMVolume();
    }

    public void LowerSFXVolume()
    {
        AudioManager.instance.LowerSFXVolume();
    }

    public void LowerBGMVolume()
    {
        AudioManager.instance.LowerBGMVolume();
    }
}
