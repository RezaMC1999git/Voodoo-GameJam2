using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUp_Line : MonoBehaviour
{
    public float changePositionSpeed = 0.5f; 
    public bool isIt2Brushy;
    public bool isIt3Brushy;
    public GameObject brush1;
    public GameObject brush2;
    public GameObject brush3;
    public GameObject fakeBrush;

    private GameObject headColor1;
    private GameObject headColor2;
    private GameObject headColor3;
    private bool doOnce1 = true;
    private bool doOnce2 = true;
    private bool doOnce3 = true;

    private void Start()
    {
        headColor1 = brush1.transform.GetChild(1).transform.GetChild(0).gameObject;
        headColor2 = brush2.transform.GetChild(1).transform.GetChild(0).gameObject;
        if(brush3)
            headColor3 = brush3.transform.GetChild(1).transform.GetChild(0).gameObject;
    }
    private void LateUpdate()
    {
        if (headColor1.tag == "WhiteBrush")
        {
            if (isIt2Brushy)
            {
                if (doOnce1)
                {
                    StartCoroutine(FirstOf2BrushyDestroyed());
                    brush2.transform.position = Vector3.MoveTowards(brush2.transform.position,
                        brush1.transform.position, changePositionSpeed * Time.deltaTime);
                }
            
            }
            if (isIt3Brushy)
            {
                if (doOnce2)
                {
                    brush2.transform.position = Vector3.MoveTowards(brush2.transform.position,
                        brush1.transform.position, changePositionSpeed * Time.deltaTime);
                    brush3.transform.position = Vector3.MoveTowards(brush3.transform.position,
                        fakeBrush.transform.position, changePositionSpeed * Time.deltaTime);
                    StartCoroutine(FirstOf3BrushyDestroyed());
                }
            }
        }
        if (headColor2.tag == "WhiteBrush")
        {
            if (isIt3Brushy)
            {
                if (doOnce3)
                {
                    brush3.transform.position = Vector3.MoveTowards(brush3.transform.position,
                        brush2.transform.position, changePositionSpeed * Time.deltaTime);
                    StartCoroutine(SecondOf3BrushyDestroyed());
                }
            }
        }
    }

    IEnumerator FirstOf2BrushyDestroyed()
    {
        brush1.SetActive(false);
        yield return new WaitForSeconds(2f);
        doOnce1 = false;
    }

    IEnumerator FirstOf3BrushyDestroyed()
    {
        brush1.SetActive(false);
        yield return new WaitForSeconds(2f);
        doOnce2 = false;
    }

    IEnumerator SecondOf3BrushyDestroyed()
    {
        brush2.SetActive(false);
        yield return new WaitForSeconds(2f);
        doOnce3 = false;
    }
}
