using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUp_LevelParameters : MonoBehaviour
{
    public static BrushUp_LevelParameters instance;
    public GameObject[] brushes;
    public Color[] levelColors;
    public int greenBrushes;
    public int redBrushes;
    public int blueBrushes;
    public int yellowBrushes;
    public bool[] colorUsed;
    public List<int> existColors;
    private bool deleteInxed0Once, deleteInxed1Once, deleteInxed2Once, deleteInxed3Once;

    private void Start()
    {
        deleteInxed0Once = deleteInxed1Once = deleteInxed2Once = deleteInxed3Once = true;
    }
    private void Update()
    {
        updateExistColors();
        CheckWinConditions();
    }

    void updateExistColors()
    {
        if (redBrushes <= 0)
            if (deleteInxed0Once)
            {
                if(existColors.Capacity > 0)
                {
                    foreach (int num in existColors)
                    {
                        if (num == 0)
                            existColors.Remove(num);
                    }
                    deleteInxed1Once = false;
                }
            }

        if (greenBrushes <= 0)
            if (deleteInxed1Once)
            {
                if (existColors.Capacity > 0)
                {
                    foreach (int num in existColors)
                    {
                        if (num == 1)
                            existColors.Remove(num);
                    }
                    deleteInxed1Once = false;
                }
            }

        if (blueBrushes <= 0)
            if (deleteInxed2Once)
            {
                if (existColors.Capacity > 0)
                {
                    foreach (int num in existColors)
                    {
                        if (num == 2)
                            existColors.Remove(num);
                    }
                    deleteInxed2Once = false;
                }
            }

        if (yellowBrushes <= 0)
            if (deleteInxed3Once)
            {
                if (existColors.Capacity > 0)
                {
                    foreach (int num in existColors)
                    {
                        if (num == 3)
                            existColors.Remove(num);
                    }
                    deleteInxed3Once = false;
                }
            }
    }

    void CheckWinConditions()
    {
        if(redBrushes == 0 && greenBrushes == 0 && blueBrushes == 0 && yellowBrushes == 0)
        {
            int randDeath = Random.Range(0, brushes.Length);
            Destroy(brushes[randDeath]);
            StartCoroutine(changeSixOclockPos());
            greenBrushes = 1;
        }
    }

    IEnumerator changeSixOclockPos()
    {
        yield return new WaitForSeconds(1f);
        Vector3 newsixOclcokPos = FindObjectOfType<BrushUp_Ball>().sixOclockTransform.position;
        newsixOclcokPos.y -= 10f;
        FindObjectOfType<BrushUp_Ball>().sixOclockTransform.position = newsixOclcokPos;
    }
}
