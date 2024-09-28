using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 getCameraFollowPos;
    public float cameraFollowSpeed = 1f;
    public void Setup(Vector3 getCameraFollowPos)
    {
        this.getCameraFollowPos = getCameraFollowPos;
    }

    private void Update()
    {
        HandleFollow();
    }
    void HandleFollow()
    {
        Vector3 cameraFollowPosition = getCameraFollowPos;
        cameraFollowPosition.x = transform.position.x;
        cameraFollowPosition.z = transform.position.z;

        if (cameraFollowPosition.y>=0)
            transform.position = cameraFollowPosition;
        //Vector3 cameraMoveDir = (cameraFollowPosition - transform.position);
        //float distance = Vector3.Distance(cameraFollowPosition,transform.position);
        //transform.position = transform.position + (cameraMoveDir * distance * cameraFollowSpeed * Time.deltaTime);
    }
}
