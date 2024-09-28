using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_FinishLine : MonoBehaviour
{
    private BB_GameController gameController;
    public GameObject winPanel;
    public bool isLevelPassed = false;
    public float xVelocity = 30f;
    public float yVelocity = 30f;

    private void Start()
    {
        gameController = FindObjectOfType<BB_GameController>();
    }
    private void Update()
    {
        if(gameController.currentMattHave >= gameController.totallMatNeeded)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            isLevelPassed = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.GetComponent<BB_Player>())
        {
            if (isLevelPassed)
            {
                winPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                StartCoroutine(StopBall(obj));
            }
        }
    }
    IEnumerator StopBall(GameObject ball)
    {
        ball.GetComponent<Rigidbody>().velocity = new Vector3(xVelocity, yVelocity, 0f);
        ball.GetComponent<BB_Player>().isMovingForward = false;
        yield return new WaitForSeconds(5f);
        ball.GetComponent<BB_Player>().isMovingForward = true;
    } 
}
