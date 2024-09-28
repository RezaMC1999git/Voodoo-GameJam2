using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_Edge : MonoBehaviour
{
    public float pushBackPower = 25f;
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<Stairs_Player>() != null)
        {
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, pushBackPower);
        }
    }
}
