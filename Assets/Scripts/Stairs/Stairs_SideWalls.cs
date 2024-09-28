using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_SideWalls : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<Stairs_Enemy>())
        {
            if (obj.GetComponent<Stairs_Enemy>().isWantonLeftBall == true)
            {
                obj.GetComponent<Stairs_Enemy>().isWantonLeftBall = false;
                obj.GetComponent<Stairs_Enemy>().isWantonRightBall = true;
            }

            else if (obj.GetComponent<Stairs_Enemy>().isWantonRightBall == true)
            {
                obj.GetComponent<Stairs_Enemy>().isWantonRightBall = false;
                obj.GetComponent<Stairs_Enemy>().isWantonLeftBall = true;
            }
        }
    }
}
