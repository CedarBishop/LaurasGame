using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static event System.Action FailedLetter;
    public Text timerText;
    float timer;
    void Start()
    {
        Respawner.InitialisedLetterTimer += SetTimer;
    }

    private void OnDestroy()
    {
        Respawner.InitialisedLetterTimer -= SetTimer;
    }

    void Update()
    {
        if (Respawner.instance.gameIsOver == false)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                if (FailedLetter != null)
                {
                    FailedLetter();
                }
            }
            timerText.text = timer.ToString("F1");
        }
        else
        {
            timerText.gameObject.SetActive(false);
        }        
    }

    void SetTimer (float newTime)
    {
        timer = newTime;
    }
}
