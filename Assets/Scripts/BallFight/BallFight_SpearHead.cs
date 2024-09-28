using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFight_SpearHead : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Enemy>())
        {
            obj.GetComponent<BallFight_Enemy>().TakeDamage();
        }
        if (obj.GetComponent<BallFight_Player>())
        {
            obj.GetComponent<BallFight_Player>().TakeDamage();
        }
    }
}
