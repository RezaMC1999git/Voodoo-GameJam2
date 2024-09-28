using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagones_CameraMove : MonoBehaviour
{
    private Vector3 getCameraFollowPos;
    private Vector3 startTouchPos;
    private Vector3 endTouchPos;
    public Vector3 changePos;
    public bool isLevelInProgress = true;
    public void Setup(Vector3 getCameraFollowPos)
    {
        this.getCameraFollowPos = getCameraFollowPos;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (isLevelInProgress)
            {
                HandleSwipe();
            }
        }
    }
    void HandleSwipe()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            startTouchPos = touch.position;
        }
        if (touch.phase == TouchPhase.Moved)
        {
            endTouchPos = touch.position;
            changePos = new Vector3((endTouchPos.y - startTouchPos.y) / 1000f,
                0f, ((startTouchPos.x - endTouchPos.x) / 1000f));
            transform.position += changePos;
        }
    }
}
