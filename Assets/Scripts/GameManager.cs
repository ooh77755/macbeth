using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int correctDrops = 0;
    int totalDrops = 0;
    public int winThreshold = 4;

    public Flowchart fC;
    public GameObject arrow;
    public GameObject thanksBlock;
    public GameObject tutCanvas;
    public TextMeshProUGUI dropsText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        dropsText.text = $"{totalDrops}/{winThreshold}";
    }

    public void RegisterDrop(bool isCorrect)
    {
        totalDrops++;

        if(dropsText.text != null)
        {
            dropsText.text = $"{totalDrops}/{winThreshold}";

        }

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
                RestartSceneSlow();
            }
        }
    }

    private void WinGame()
    {
        fC.ExecuteBlock("Win");
        Destroy(tutCanvas);
        Invoke("LoadScene", 1);
    }

    public void RestartSceneFast()
    {
        SceneManager.LoadScene(1);
    }
    
    private void RestartSceneSlow()
    {
        fC.ExecuteBlock("Lose");
        Destroy(tutCanvas);
        arrow.SetActive(true);
        
    }

    void LoadScene()
    {
        thanksBlock.SetActive(true);
    }
}
