using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int correctDrops = 0;
    int totalDrops = 0;
    public int winThreshold = 4;

    public Flowchart fC;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterDrop(bool isCorrect)
    {
        totalDrops++;

        if (isCorrect)
        {
            correctDrops++;
        }

        if(totalDrops>=winThreshold)
        {
            if (correctDrops >= winThreshold)
            {
                WinGame();
            }
            else
            {
                RestartScene();
            }
        }
    }

    private void WinGame()
    {
        fC.ExecuteBlock("Win");
    }

    private void RestartScene()
    {
        fC.ExecuteBlock("Lose");
        Invoke("LoadScene", 2);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
