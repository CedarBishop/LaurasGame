using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static event System.Action FailedLetter;
    public Text timerText;
    float timer;
    Color currentColor = Color.magenta;
    Color newTargetColor;
    public float colorChangeSpeed = 1;

    public Text[] allText;
    void Start()
    {
        Respawner.InitialisedLetterTimer += SetTimer;
        StartCoroutine("ChangeTargetColor");
    }

    private void OnDestroy()
    {
        Respawner.InitialisedLetterTimer -= SetTimer;
    }

    void Update()
    {
        currentColor = Color.Lerp(currentColor,newTargetColor,colorChangeSpeed * Time.deltaTime);
        for (int i = 0; i < allText.Length; i++)
        {
            allText[i].color = currentColor;
        }
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

    IEnumerator ChangeTargetColor ()
    {
        while (true)
        {
            newTargetColor = new Color(Random.Range(0, 1.0f),Random.Range(0, 1.0f),Random.Range(0,1.0f),1);
            yield return new WaitForSeconds(1);
        }
    }
}
