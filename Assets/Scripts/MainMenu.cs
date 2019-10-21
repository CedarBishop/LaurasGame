using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Gamename = "GameScene";
    public GameObject mainMenuParent;
    public GameObject settingsMenuParent;

    private void Start()
    {
        mainMenuParent.gameObject.SetActive(true);
        settingsMenuParent.gameObject.SetActive(false);
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(Gamename);
    }

    public void TransistionToSettings ()
    {
        mainMenuParent.gameObject.SetActive(false);
        settingsMenuParent.gameObject.SetActive(true);
    }

    public void TransistionToMainMenu ()
    {
        mainMenuParent.gameObject.SetActive(true);
        settingsMenuParent.gameObject.SetActive(false);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
