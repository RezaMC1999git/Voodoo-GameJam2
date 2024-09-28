using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUp_HeadColor : MonoBehaviour
{
    public BrushUp_LevelParameters levelParameters;
    public int headIndex = 0;
    private BrushUp_ColorsSample colorsSample;
    private BrushUp_Ball ball;
    private Renderer renderer;
    private Material headBrushMaterial;
    private Color headColor;

    private void Start()
    {
        ball = FindObjectOfType<BrushUp_Ball>();
        colorsSample = FindObjectOfType<BrushUp_ColorsSample>();
        renderer = GetComponent<Renderer>();
        headBrushMaterial = renderer.material;
        //headColor = FindTheMaterialColor();
        headColor = levelParameters.levelColors[headIndex];
        gameObject.tag = FindTag();
        headBrushMaterial.color = headColor;
    }

    Color FindTheMaterialColor()
    {
        Color colorToReturn = Color.black;
        for(int i = 0; i < levelParameters.colorUsed.Length; i++)
        {
            if (!levelParameters.colorUsed[i])
            {
                levelParameters.colorUsed[i] = true;
                colorToReturn = levelParameters.levelColors[i];
                break;
            }
        }
        return colorToReturn;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BrushUp_Ball>())
        {
            if(obj.tag == gameObject.tag)
            {
                HandleLevelParametersValues(obj);
                headBrushMaterial.color = Color.white;
                gameObject.tag = "WhiteBrush";
            }
            else
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    void HandleLevelParametersValues(GameObject ball)
    {
        if (headColor == colorsSample.redColor)
        {
            if (levelParameters.redBrushes > 0)
                levelParameters.redBrushes--;
        }

        if (headColor == colorsSample.greenColor)
        {
            if (levelParameters.greenBrushes > 0)
                levelParameters.greenBrushes--;
        }

        if (headColor == colorsSample.blueColor)
        {
            if(levelParameters.blueBrushes>0)
                levelParameters.blueBrushes--;
        }

        if (headColor == colorsSample.yellowColor)
        {
            if (levelParameters.yellowBrushes > 0)
                levelParameters.yellowBrushes--;
        }
    }
    string FindTag()
    {
        string tagToReturn = "";
        if (headColor == colorsSample.redColor)
            tagToReturn = "RedBrush";
        if (headColor == colorsSample.greenColor)
            tagToReturn = "GreenBrush";
        if (headColor == colorsSample.blueColor)
            tagToReturn = "BlueBrush";
        if (headColor == colorsSample.yellowColor)
            tagToReturn = "YellowBrush";
        return tagToReturn;
    }
}
