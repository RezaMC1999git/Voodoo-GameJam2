using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform intakerTransform;
    public bool canBeCloned = false;
    public float moveSpeed = 17f;
    BallMove ballMove;

    private void Start()
    {
        intakerTransform = GameObject.FindGameObjectWithTag("Intaker Bubble").transform;
        ballMove = gameObject.GetComponent<BallMove>();
        StartCoroutine(ActiveBall());
    }

    IEnumerator ActiveBall()
    {
        yield return new WaitForSeconds(3f);
        canBeCloned = true;
    }
}
