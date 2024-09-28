using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallFight_Phrases : MonoBehaviour
{
    [SerializeField] string[] phrases;
    private int index = 1;
    private int lastIndexUSed;
    private void Start()
    {
        StartCoroutine(ChnagePhrase());
    }
    IEnumerator ChnagePhrase()
    {
        index = Random.Range(0, phrases.Length);
        if (index == lastIndexUSed)
            index = Random.Range(0, phrases.Length);
        else
            lastIndexUSed = index;
        GetComponent<TextMeshPro>().text = phrases[index];
        yield return new WaitForSeconds(3f);
        GetComponent<TextMeshPro>().text = null;
        yield return new WaitForSeconds(3f);
        StartCoroutine(ChnagePhrase());
    }
}
