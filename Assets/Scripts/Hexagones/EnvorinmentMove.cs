using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnvorinmentMove : MonoBehaviour
{
    public GameObject firstPlatform;
    public GameObject hexagonesParent;
    public Vector3 platformsEndTouchPos;
    public Vector3 hexagonsEndTouchPos;
    bool gameStarted = false;

    private void Start()
    {
        StartCoroutine(stopTheAnimation());
        platformsEndTouchPos = new Vector3(0f, 0f, 0f);
        hexagonsEndTouchPos = new Vector3(0f, 0f, 0f);
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(gameStarted)
                HandleMovement();
            if(touch.phase == TouchPhase.Ended)
            {
                platformsEndTouchPos = transform.localPosition;
                hexagonsEndTouchPos = hexagonesParent.transform.localPosition;
            }
        }
    }
    void HandleMovement()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Capacity > 0)
        {
            if (results[0].gameObject.GetComponent<EnvorinmentMove>() != null)
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f));
                touchPos.y = 0f;
                transform.localPosition = platformsEndTouchPos + touchPos;
                hexagonesParent.transform.localPosition = hexagonsEndTouchPos + touchPos;
            }
        }
    }
    IEnumerator stopTheAnimation()
    {
        yield return new WaitForSeconds(4f);
        gameStarted = true;
        yield return new WaitForSeconds(1f);
        firstPlatform.GetComponent<Animator>().enabled = false;
    }
}
