using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFight_Spears : MonoBehaviour
{
    public GameObject upSpears;
    public GameObject leftSpears;
    public GameObject downSpears;
    public GameObject rightSpears;

    private int index;
    private int lastIndexUsed;


    private void Start()
    {
        StartCoroutine(LetTheFunBegin());
    }

    IEnumerator LetTheFunBegin()
    {
        index = Random.Range(0, 4);
        if (index == lastIndexUsed)
            index = Random.Range(0, 4);
        else
            lastIndexUsed = index;
        PickSide().GetComponent<Animator>().SetTrigger("Active");
        yield return new WaitForSeconds(4f);
        PickSide().GetComponent<Animator>().SetTrigger("DeActive");
        StartCoroutine(LetTheFunBegin());
    }
    private GameObject PickSide()
    {
        GameObject sideToReturn = null;
        switch (index)
        {
            case 0:
                sideToReturn = upSpears;
                break;
            case 1:
                sideToReturn = leftSpears;
                break;
            case 2:
                sideToReturn = downSpears;
                break;
            case 3:
                sideToReturn = rightSpears;
                break;
        }
        return sideToReturn;
    } 
}
