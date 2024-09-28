using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intake_GameController : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI currentBall;
    public TextMeshProUGUI totallBall;
    public int currnetBallsNum;
    public int totallNeedBallsNum;
    public string levelName;

    private void Update()
    {
        if(currnetBallsNum >= totallNeedBallsNum)
        {
            Time.timeScale = 0f;
            FindObjectOfType<Intaker>().isGameInProgress = false;
            winPanel.SetActive(true);
        }    
    }

    private void Start()
    {
        currentBall.text = "0";
        totallBall.text = totallNeedBallsNum.ToString();
    }

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
        winPanel.SetActive(false);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void BallIntaked()
    {
        currnetBallsNum++;
        currentBall.text = currnetBallsNum.ToString();
    }
}
