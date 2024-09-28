using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFight_JumpArea : MonoBehaviour
{
    public float jumpForce = 20f;
    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Enemy>())
        {
            if(obj.GetComponent<BallFight_Enemy>().isAlive)
                Jump(obj);
        }
    }
    public void Jump(GameObject enemy)
    {
        Rigidbody rigidBody = enemy.GetComponent<Rigidbody>();
        if (enemy.transform.position.y == 1.5f)
            rigidBody.velocity = new Vector3(0f, jumpForce, 0f);
    }
}
