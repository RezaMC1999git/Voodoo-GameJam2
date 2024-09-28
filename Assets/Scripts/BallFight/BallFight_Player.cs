using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallFight_Player : MonoBehaviour
{
    public float speed = 1f;
    public int health = 3;
    public Rigidbody rigidBody;
    public Transform enemyTransform;
    public float chaseSpeed = 2f;
    public bool isInsideDoubleTapArea;
    public bool isLevel2;
    public GameObject winPanel;
    public Animator enemyAnimator;
    public TextMeshPro healthText;
    public GameObject restartPanel;

    private Vector3 startTouchPos;
    private Vector3 endTouchPos;
    private Vector3 changePos;

    private void Start()
    {
        Time.timeScale = 1f;
        if(healthText != null)
            healthText.text = health.ToString();
        Physics.gravity = new Vector3(0f, -20f, 0f);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            HandleSwipe();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            restartPanel.SetActive(true);
        }
    }
    void HandleSwipe()
    {
        Touch touch = Input.GetTouch(0);
        /*if (touch.tapCount == 2)
        {
            if (isInsideDoubleTapArea)
            {
                transform.position = Vector3.MoveTowards(transform.position, enemyTransform.position, chaseSpeed * Time.deltaTime);
            }
        }*/

        if (touch.phase == TouchPhase.Began)
        {
            startTouchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 45f));
        }

        if (touch.phase == TouchPhase.Moved)
        {
            endTouchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 45f));
            changePos = new Vector3((endTouchPos.x - startTouchPos.x)*2f,
                0f, (endTouchPos.z - startTouchPos.z)*2f);
            transform.position += (changePos * speed * Time.deltaTime);
            LockPosOutLimits();
        }

        if(touch.phase == TouchPhase.Ended)
        {
            if (!isLevel2)
            {
                if (transform.position.y == 1.5f)
                    rigidBody.velocity = new Vector3(0f, 18f, 0f);
            }
        }
    }
    void LockPosOutLimits()
    {
        if (transform.position.x >= 14.2f)
        {
            Vector3 temp = transform.position;
            temp.x = 14.2f;
            transform.position = temp;
        }
        if (transform.position.x <= -0.4f)
        {
            Vector3 temp = transform.position;
            temp.x = -0.4f;
            transform.position = temp;
        }
        if (transform.position.z >= 23.5f)
        {
            Vector3 temp = transform.position;
            temp.z = 23.5f;
            transform.position = temp;
        }
        if (transform.position.z <= -16f)
        {
            Vector3 temp = transform.position;
            temp.z = -16f;
            transform.position = temp;
        }
    }
    public void TakeDamage()
    {
        health--;
        if (health > 0)
            healthText.text = health.ToString();
        else
        {
            healthText.gameObject.SetActive(false);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Enemy>())
        {
            if (isLevel2)
            {
                Vector3 dir = other.contacts[0].point - transform.position;
                dir = -dir.normalized;
                GetComponent<Rigidbody>().velocity = dir * 25f;
            }
        }
    }
}
