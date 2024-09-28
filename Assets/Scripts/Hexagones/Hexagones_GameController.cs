using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hexagones_GameController : MonoBehaviour
{
    public GameObject pausePanel;

    public List<GameObject> hexaGones;
    public Material whiteMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    public Material orangeMaterial;
    public Material yellowMaterial;

    [Header("Number Of Each Hex Type")]
    public int whiteHexNumber;
    public GameObject[] whiteHexs;
    private int redHexNumber;
    private int blueHexNumber;
    private int orangeHexNumber;
    private int yellowHexNumber;

    [Header("UI")]
    public TextMeshProUGUI currentWhiteHexs;
    public TextMeshProUGUI allWhiteHexs;
    public TextMeshPro redHexagonBombCountDown;
    public GameObject winPanel;

    public string levelName;
    public int whiteHexFound = 0;
    private List<int> numbersUsed;
    private int randIndex;

    private void Start()
    {
        numbersUsed = new List<int>(hexaGones.Count);
        //SetGoalZones();
        Physics.gravity = new Vector3(0f, -20f, 0f);
        currentWhiteHexs.text = "0";
        allWhiteHexs.text = whiteHexNumber.ToString();
    }
    private void Update()
    {
        if(whiteHexFound == whiteHexNumber)
        {
            StartCoroutine(WinLevel());
        }

        if (Input.GetKeyDown(KeyCode.Return))
            Application.LoadLevel("MainMenu");
    }
    void SetGoalZones() 
    {
        for(int i = 0; i < whiteHexNumber; i++)
        {
            randIndex = Random.Range(0, hexaGones.Count);
            foreach (int used in numbersUsed)
            {
                if (randIndex == used)
                {
                    randIndex = MakeNewRand();
                }
            }
            hexaGones[randIndex].GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(whiteMaterial);
            hexaGones[randIndex].tag = "WhiteHex";
            numbersUsed.Add(randIndex);
        }
        SetDangerZones();
    }
    void SetDangerZones()
    {
        for (int i = 0; i < redHexNumber; i++)
        {
            randIndex = Random.Range(0, hexaGones.Count);
            foreach(int used in numbersUsed)
            {
                if(randIndex == used)
                {
                    randIndex = MakeNewRand();
                }
            }
            hexaGones[randIndex].GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(redMaterial);
            hexaGones[randIndex].tag = "RedHex";
            numbersUsed.Add(randIndex);
        }
        SetPortalZones();
    }
    void SetPortalZones()
    {
        for (int i = 0; i < blueHexNumber; i++)
        {
            randIndex = Random.Range(0, hexaGones.Count);
            foreach (int used in numbersUsed)
            {
                if (randIndex == used)
                {
                    randIndex = MakeNewRand();
                }
            }
            hexaGones[randIndex].GetComponent<Renderer>().materials[1].CopyPropertiesFromMaterial(blueMaterial);
            hexaGones[randIndex].tag = "BlueHex";
            numbersUsed.Add(randIndex);
        }
        SetVariableZones();
    }
    void SetVariableZones()
    {
        for (int i = 0; i < orangeHexNumber; i++)
        {
            randIndex = Random.Range(0, hexaGones.Count);
            foreach (int used in numbersUsed)
            {
                if (randIndex == used)
                {
                    randIndex = MakeNewRand();
                }
            }
            hexaGones[randIndex].GetComponent<Renderer>().materials[1].CopyPropertiesFromMaterial(orangeMaterial);
            hexaGones[randIndex].tag = "OrangeHex";
            numbersUsed.Add(randIndex);
        }
        SetSafeZones();
    }

    void SetSafeZones()
    {
        for (int i = 0; i < yellowHexNumber; i++)
        {
            randIndex = Random.Range(0, hexaGones.Count);
            foreach (int used in numbersUsed)
            {
                if (randIndex == used)
                {
                    randIndex = MakeNewRand();
                }
            }
            hexaGones[randIndex].GetComponent<Renderer>().materials[1].CopyPropertiesFromMaterial(yellowMaterial);
            hexaGones[randIndex].tag = "YellowHex";
            numbersUsed.Add(randIndex);
        }
        MakeLastPiece();
    }

    void MakeLastPiece()
    {
        foreach(GameObject hex in hexaGones)
        {
            if (hex.GetComponent<MeshRenderer>().materials[1] == null)
            {
                hex.gameObject.tag = "WhiteHex";
                hex.GetComponent<MeshRenderer>().materials[1].CopyPropertiesFromMaterial(whiteMaterial);
            }
        }
    }

    int MakeNewRand() 
    {
        int numToReturn = Random.Range(0,hexaGones.Count);
        bool stayInWhile = true;
        while (stayInWhile)
        {
            for (int j = 0; j < numbersUsed.Count; j++)
            {
                if(numToReturn == numbersUsed[j])
                {
                    stayInWhile = true;
                    numToReturn = Random.Range(0, hexaGones.Count);
                    j = 0;
                }
            }
            stayInWhile = false;
        }
        return numToReturn;
    }

    public void WhiteHexagonFounded()
    {
        whiteHexFound++;
        currentWhiteHexs.text = whiteHexFound.ToString();
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
        pausePanel.SetActive(false);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(1.5f);
        winPanel.SetActive(true);
        FindObjectOfType<Hexagones_CameraMove>().isLevelInProgress = false;
        Time.timeScale = 0f;
    }
}
