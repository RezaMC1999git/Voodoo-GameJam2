using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Player : MonoBehaviour
{
    public float a = 2f;
    public GameObject restartPanel;
    public bool isMovingForward = true;
    public float moveSpeed = 2f;
    public bool ballComeDownWeGotHeadache = false;

    private Rigidbody rigidBody;
    private bool callOnce = true;
    private bool holding = false;
    private Vector3 moveForward = new Vector3(1f, 0f, 0f);
    private void Start()
    {
        Time.timeScale = 1f;
        Physics.gravity = new Vector3(0f, -20f, 0);
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (isMovingForward)
        {
            transform.position -= moveForward * moveSpeed * Time.deltaTime;
        }

        if (holding)
        {
            ballComeDownWeGotHeadache = true;
            rigidBody.velocity += new Vector3(0f, -a, 0f);
        }

        if (transform.position.y > 40f)
        {
            rigidBody.velocity -= new Vector3(0f, 1f, 0f);
            Vector3 newTransform = new Vector3(transform.position.x, 0f, transform.position.z);
            newTransform.y = 40f;
            transform.position = newTransform;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            restartPanel.SetActive(true);
        }

        if (Input.touchCount > 0)
        {
            callOnce = true;
            if (callOnce)
            {
                StartCoroutine(Test());
                callOnce = false;
            }
        }
        else if(Input.touchCount == 0)
        {
            ballComeDownWeGotHeadache = false;
        }
    }
    IEnumerator Test()
    {
        yield return new WaitForSeconds(0.1f);
        if(Input.touchCount == 0) //Tap
        {
            rigidBody.velocity = new Vector3(0f, 9f, 0f);
            holding = false;
        }
        if (Input.touchCount == 1) //Hold
        {
            ballComeDownWeGotHeadache = true;
            rigidBody.velocity += new Vector3(0f, -a, 0f);
            //holding = true;
        }
    }

}
