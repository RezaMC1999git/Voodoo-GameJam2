using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFight_GameController : MonoBehaviour
{
    public string levelName;
    public GameObject pausePanel;
    public void GoToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void GoToLevel()
    {
        Application.LoadLevel(levelName);
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
