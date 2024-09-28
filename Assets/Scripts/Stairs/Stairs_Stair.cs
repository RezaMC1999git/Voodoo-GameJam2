using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_Stair : MonoBehaviour
{
    public float jumpForce = 3f;
    public bool activated = false;
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if(obj.GetComponent<Stairs_Player>() != null || obj.GetComponent<Stairs_Enemy>() != null)
        {
            activated = true;
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpForce, 0f);
        }
    }
}
