using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public GameObject hintPanel;
    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject[] gamePages;
    public TextMeshProUGUI hintText;
    private bool needToCheckArrows = true;
    public int numberOfAllGames;
    public int currentGame;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("LAST_LEVEL"))
        {
            PlayerPrefs.SetInt("LAST_LEVEL", 0);
            gamePages[PlayerPrefs.GetInt("LAST_LEVEL")].SetActive(true);
        }
        else
        {
            currentGame = PlayerPrefs.GetInt("LAST_LEVEL");
            gamePages[currentGame].SetActive(true);
        }
    }
    public void StartGame(string LevelName)
    {
        Application.LoadLevel(LevelName);
        PlayerPrefs.SetInt("LAST_LEVEL", currentGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        CheckArrowsAppearance();
    }

    public void ShowHowToPlayCanvas(string toturial)
    {
        Time.timeScale = 0f;
        hintText.text = toturial;
        needToCheckArrows = false;
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        hintPanel.SetActive(true);
    }

    public void GotIt()
    {
        Time.timeScale = 1f;
        needToCheckArrows = true;
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        hintPanel.SetActive(false);
    }

    public void LoadNextGame()
    {
        currentGame++;
        gamePages[currentGame].SetActive(true);
        gamePages[currentGame - 1].SetActive(false);
    }

    public void LoadPreviousGame()
    {
        currentGame--;
        gamePages[currentGame].SetActive(true);
        gamePages[currentGame +1].SetActive(false);
    }

    void CheckArrowsAppearance()
    {
        if (needToCheckArrows)
        {
            if (currentGame == 0)
            {
                leftArrow.SetActive(false);
                rightArrow.SetActive(true);
            }
            if (currentGame == 5)
            {
                rightArrow.SetActive(false);
                leftArrow.SetActive(true);
            }
            else if (currentGame > 0 && currentGame < 6)
            {
                rightArrow.SetActive(true);
                leftArrow.SetActive(true);
            }
        }
    }
}
