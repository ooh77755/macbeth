using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int correctDrops = 0;
    public int winThreshold = 4;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterDrop(bool isCorrect)
    {
        if(isCorrect)
        {
            correctDrops++;
            if(correctDrops >= winThreshold)
            {
                WinGame();
            }
        }
    }

    private void WinGame()
    {
        print("WIN!!");
    }
}
