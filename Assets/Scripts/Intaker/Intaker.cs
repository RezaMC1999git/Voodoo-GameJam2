using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Intaker : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isGameInProgress = true;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(isGameInProgress)
                HandleTouch();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
    }

    void HandleTouch()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Capacity > 0)
        {
            if (results[0].gameObject.CompareTag("Intaker"))
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f));
                touchPos.y = touchPos.z = 0f;
                transform.position = touchPos;
            }
        }
    }
}
