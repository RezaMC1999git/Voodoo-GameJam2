using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BB_Player>())
        {
            StartCoroutine(PushBallBack(obj));
        }
    }
    IEnumerator PushBallBack(GameObject ball)
    {
        ball.GetComponent<BB_Player>().isMovingForward = false;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(4f, 8f, 0f);
        yield return new WaitForSeconds(1.3f);
        ball.GetComponent<BB_Player>().isMovingForward = true;
    }
}
