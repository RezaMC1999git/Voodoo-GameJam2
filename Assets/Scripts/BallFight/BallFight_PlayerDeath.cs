using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFight_PlayerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Enemy>())
            Application.LoadLevel(Application.loadedLevel);
    }
}
