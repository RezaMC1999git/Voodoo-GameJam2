using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<Stairs_Player>())
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (obj.GetComponent<Stairs_Enemy>())
        {
            Destroy(obj);
        }
    }
}
