using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_Enemy : MonoBehaviour
{
    public float moveBackwardSpeed = 5f;
    public float pushBackPower = 25f;
    public bool isWantonLeftBall;
    public bool isWantonRightBall;
    public bool isAttacking = true;

    void Update()
    {
        if (isAttacking)
        {
            transform.position -= Vector3.back * moveBackwardSpeed * Time.deltaTime;
            if (isWantonLeftBall)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(30f, -15f, 0f);
            }

                //transform.position -= Vector3.left * moveBackwardSpeed * Time.deltaTime;
            if (isWantonRightBall)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-30f, -15f, 0f);
            }

            //transform.position -= Vector3.right * moveBackwardSpeed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if(obj.GetComponent<Stairs_Player>() != null)
        {
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, pushBackPower);
        }
    }
}
