using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUp_Ball : MonoBehaviour
{
    Vector3 middleScreenPos;
    public GameObject pausePanel;
    public float stickToBrushesSpeed = 2f;
    public Transform sixOclockTransform;

    private Material ballMaterial;
    private BrushUp_HintCanvas hintCanvas;
    private Color ballColor;
    private Renderer renderer;
    public BrushUp_LevelParameters levelParameters;
    public int firstRandIndex;
    public int lastRandIndex;

    private void Start()
    {
        Time.timeScale = 1f;
        renderer = GetComponent<Renderer>();
        middleScreenPos = transform.position;
        ballMaterial = renderer.material;
        hintCanvas = FindObjectOfType<BrushUp_HintCanvas>();
        firstRandIndex = Random.Range(0,4);
        lastRandIndex = Random.Range(0,4);
        if (firstRandIndex == lastRandIndex)
            lastRandIndex = Random.Range(0,4);
        StartCoroutine(ChangeBallColor());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            HandleTouch();
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                middleScreenPos, stickToBrushesSpeed * Time.deltaTime);
        }
    }

    void HandleTouch()
    {
        if(transform.position != sixOclockTransform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                sixOclockTransform.position, stickToBrushesSpeed * Time.deltaTime);
        }
    }

    IEnumerator ChangeBallColor()
    {
        ballColor = FindTheMaterialColor();
        ballMaterial.color = ballColor;
        yield return new WaitForSeconds(4f);
        StartCoroutine(ChangeBallColor());
    }

    Color FindTheMaterialColor()
    {
        BrushUp_ColorsSample colorsSample = FindObjectOfType<BrushUp_ColorsSample>();
        Color colorToReturn = Color.black;
        firstRandIndex = lastRandIndex;
        lastRandIndex = Random.Range(levelParameters.existColors[0], levelParameters.existColors[levelParameters.existColors.Count -1]);
        CheckLastIndex();   
        if(firstRandIndex == lastRandIndex)
            lastRandIndex = Random.Range(levelParameters.existColors[0], levelParameters.existColors[levelParameters.existColors.Count - 1]);
        switch (firstRandIndex)
        {
            case 0:
                colorToReturn = colorsSample.redColor;
                hintCanvas.RedBall(lastRandIndex);
                gameObject.tag = "RedBrush";
                break;
            case 1:
                colorToReturn = colorsSample.greenColor;
                hintCanvas.GreenBall(lastRandIndex);
                gameObject.tag = "GreenBrush";
                break;
            case 2:
                colorToReturn = colorsSample.blueColor;
                hintCanvas.BlueBall(lastRandIndex);
                gameObject.tag = "BlueBrush";
                break;
            case 3:
                colorToReturn = colorsSample.yellowColor;
                hintCanvas.YellowBall(lastRandIndex);
                gameObject.tag = "YellowBrush";
                break;
        }
        return colorToReturn;
    }
    void CheckLastIndex()
    {
        int lastColorChance = Random.Range(0, 10);
        if (lastRandIndex == 0)
        {
            if (lastColorChance >=0 && lastColorChance < 6)
                lastRandIndex = 3;
        }
        if (lastRandIndex == 1)
        {
            if (lastColorChance >= 0 && lastColorChance < 6)
                lastRandIndex = 3;
        }
        /*if (lastRandIndex == 2)
        {
            if (lastColorChance == 0)
                lastRandIndex = 3;
        }*/
    }
}
