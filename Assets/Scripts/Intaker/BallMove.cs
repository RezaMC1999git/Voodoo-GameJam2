using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Ball ballScript;
    private Intake_GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<Intake_GameController>();
        ballScript = gameObject.GetComponent<Ball>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ballScript.intakerTransform.position,
            ballScript.moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Ball Detector"))
        {
            gameController.BallIntaked();
            Destroy(gameObject);
        }
    }
}
