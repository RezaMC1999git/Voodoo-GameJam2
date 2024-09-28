using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BB_GameController : MonoBehaviour
{
    public TextMeshProUGUI currentMatt;
    public TextMeshProUGUI requiredMatt;
    public GameObject pausePanel;
    public string levelName;
    public int totallMatNeeded = 40;
    public int currentMattHave = 0;

    private void Start()
    {
        currentMatt.text = "0";
        requiredMatt.text = totallMatNeeded.ToString();
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    public void GoToLevel()
    {
        Application.LoadLevel(levelName);
    }

    public void MattCollected()
    {
        currentMattHave++;
        currentMatt.text = currentMattHave.ToString();
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
