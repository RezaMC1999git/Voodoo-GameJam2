using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_KillDeathTrigger : MonoBehaviour
{
    public GameObject deathTrigger;
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BB_Player>())
        {
            Destroy(deathTrigger);
        }
    }
}
