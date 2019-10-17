using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BdayLetters { H,A1,P1,P2,Y1,B,I,R1,T,H2,D,A2,Y2,L,A3,U,R2,A4}

public class Respawner : MonoBehaviour
{
    public static System.Action CompleteGame;
    public static event System.Action<float> InitialisedLetterTimer;
    public static Respawner instance = null;
    static BdayLetters currentLetter;
    public bool gameIsOver;
    public CheckpointSystem[] checkpointSystems;

    private PlayerController player;

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
    }


    private void Start()
    {
        Timer.FailedLetter += RestartLetter;


        player = FindObjectOfType<PlayerController>();
        if (InitialisedLetterTimer != null)
        {
            InitialisedLetterTimer(checkpointSystems[(int)currentLetter].timeToCompleteLetter);
        }
    }

    private void OnDestroy()
    {
        Timer.FailedLetter -= RestartLetter;
    }

    void RestartLetter ()
    {
        player.transform.position = checkpointSystems[(int)currentLetter].spawnpoint.transform.position;
        if (InitialisedLetterTimer != null)
        {
            InitialisedLetterTimer(checkpointSystems[(int)currentLetter].timeToCompleteLetter);
            checkpointSystems[(int)currentLetter].reciever.gameObject.SetActive(true);
        }
    }

    public bool CompleteLetter ()
    {
        if (currentLetter == BdayLetters.A4)
        {
            if (CompleteGame != null)
            {
                CompleteGame();
                gameIsOver = true;
                return false;
            }
        }
        currentLetter++;
        if (InitialisedLetterTimer != null)
        {
            InitialisedLetterTimer(checkpointSystems[(int)currentLetter].timeToCompleteLetter);
        }
        return true;
    }

    public CheckpointSystem GetCheckpointSystem(int index)
    {
        return checkpointSystems[index];
    }
}

[System.Serializable]
public struct CheckpointSystem
{
    public BdayLetters bdayLetter;
    public Reciever reciever;
    public SpawnPoint spawnpoint;
    public float timeToCompleteLetter;
}

