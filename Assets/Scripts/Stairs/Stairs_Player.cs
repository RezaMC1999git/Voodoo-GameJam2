using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stairs_Player : MonoBehaviour
{
    private Vector3 firstXPos;
    public GameObject pausePanel;
    public float moveForwardSpeed = 5f;
    public float horizontalSpeed = 2.5f;
    public float test = 40f;
    private void Start()
    {
        Time.timeScale = 1f;
        Physics.gravity = new Vector3(0f, -50f, 0f);
        firstXPos = transform.position;
    }
    void Update()
    {
        transform.position -= Vector3.forward * moveForwardSpeed * Time.deltaTime; 
        if (Input.touchCount > 0)
        {
            HandleTouch();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        /*else
        {
            if(transform.position.x <= 1.45f || transform.position.x >= 1.55f)
            {
                firstXPos = new Vector3(1.5f, transform.position.y,transform.position.z);
                transform.position = Vector3.Lerp(transform.position, firstXPos, horizontalSpeed * Time.deltaTime);
            }
        }*/
    }
    
    void HandleTouch()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Capacity > 0)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, test));
            touchPos.y = transform.position.y;
            touchPos.z = transform.position.z;
            if (touchPos.x <= -25 || touchPos.x >= 25)
                LockBallPos();
            else
                transform.position = touchPos;
            /*if (results[0].gameObject.name == "Left Touch")
            {
                Vector3 leftPosLimit = new Vector3(touchPos.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, leftPosLimit, horizontalSpeed * Time.deltaTime);
            }
            if (results[0].gameObject.name == "Right Touch")
            {
                Vector3 leftPosLimit = new Vector3(touchPos.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, leftPosLimit, horizontalSpeed * Time.deltaTime);
            }*/
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("MainMenu");
    }
    void LockBallPos()
    {
        Vector3 newXPos = transform.position;
        if (transform.position.x <= -25)
        {
            newXPos.x = -25f;
        }
        if (transform.position.x >= 25)
        {
            newXPos.x = 25f;
        }
        transform.position = newXPos;
    }
}
