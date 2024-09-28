using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_HiddenTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BB_Player>())
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
