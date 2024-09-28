using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_WinStair : MonoBehaviour
{
    public bool levelFinished = false;
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if(obj.GetComponent<Stairs_Player>() != null)
        {
            obj.GetComponent<Stairs_Player>().enabled = false;
            Time.timeScale = 0f;
            levelFinished = true;
        }
    }
}
