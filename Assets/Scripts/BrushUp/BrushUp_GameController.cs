using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUp_GameController : MonoBehaviour
{
    public GameObject pausePanel;
    public string nextLevelName;

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
