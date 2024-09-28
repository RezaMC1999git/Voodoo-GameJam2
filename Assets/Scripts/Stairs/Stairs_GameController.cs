using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_GameController : MonoBehaviour
{
    public GameObject winUI;
    public GameObject winStair;
    public GameObject pausePanel;
    public string nextLevelName;

    void Update()
    {
        if (winStair.GetComponent<Stairs_WinStair>().levelFinished)
        {
            winUI.SetActive(true);
        }
    }

    public void GoToMainMenu() 
    {
        Application.LoadLevel("Main Menu");
    }

    public void GoToNextLevel()
    {
        Application.LoadLevel(nextLevelName);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
