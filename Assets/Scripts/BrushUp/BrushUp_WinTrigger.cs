using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUp_WinTrigger : MonoBehaviour
{
    public GameObject winPanel;
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.GetComponent<BrushUp_Ball>())
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
        }
    }
}
