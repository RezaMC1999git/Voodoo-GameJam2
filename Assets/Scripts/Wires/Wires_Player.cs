using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Wires_Player : MonoBehaviour
{
    public float verticalSpeed = 0.6f;
    public float cameraChangeFOVSpeed = 2.75f;
    public Transform lineRenderersParent;
    public CameraFollow cameraFollow;
    public GameObject lineRenderer;
    public Transform emptyTransform;
    Transform touchPos;
    private bool changeCameraFOVOnce = false;
    public Wires_LevelParameters levelParameters;

    List<RaycastResult> results;
    PointerEventData eventDataCurrentPosition;

    private void Start()
    {
        cameraFollow.Setup(transform.position);
    }
    void Update()
    {
        cameraFollow.Setup(transform.position);
        lineRenderersParent.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
                HandleTouchInputs();
        }
        if (changeCameraFOVOnce)
        {
            cameraFollow.GetComponent<Camera>().fieldOfView += 2f * cameraChangeFOVSpeed * Time.deltaTime;
            if (cameraFollow.GetComponent<Camera>().fieldOfView >= levelParameters.levelMaximumFOV)
                cameraFollow.GetComponent<Camera>().fieldOfView = levelParameters.levelMaximumFOV;
        }
        lockXPosOutofBounds();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("MainMenu");
    }

    void HandleTouchInputs()
    {
        eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Capacity > 0)
        {
            Transform newTouchPos = Instantiate(emptyTransform, transform.position, Quaternion.identity);
            touchPos = newTouchPos;
            touchPos.transform.parent = transform;
            touchPos.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            GameObject touchArea = results[0].gameObject;
            switch (touchArea.name)
            {
                case "right Line":
                    /*verticalSpeed = 0.6f;
                    Vector3 leftPosLimit = new Vector3(-0.25f, transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, leftPosLimit, horizontalSpeed * Time.deltaTime);*/
                    if(cameraFollow.GetComponent<Camera>().fieldOfView < levelParameters.levelMaximumFOV)
                        StartCoroutine(ChangeCameraFOV());
                    SetUpNewLineRenderers();
                    //newRightRope.transform.GetChild(0).position = transform.position;
                    //newRightRope.transform.GetChild(4).position = touchPos;
                    break;

                case "middle Line":
                    verticalSpeed = 1.2f;
                    break;

                case "left Line":
                    /*verticalSpeed = 0.6f;
                    Vector3 rightPosLimit = new Vector3(0.25f, transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, rightPosLimit, horizontalSpeed * Time.deltaTime);*/
                    if (cameraFollow.GetComponent<Camera>().fieldOfView < levelParameters.levelMaximumFOV)
                        StartCoroutine(ChangeCameraFOV());
                    SetUpNewLineRenderers();
                    break;
            }
        }
    }
    void SetUpNewLineRenderers()
    {
        GameObject newLineRenderer = Instantiate(lineRenderer, transform.position, Quaternion.identity);
        newLineRenderer.transform.parent = lineRenderersParent;
        newLineRenderer.transform.GetChild(1).GetComponent<LineRendererActivator>().lineController =
            newLineRenderer.transform.GetChild(0).gameObject.GetComponent<LineController>();

        //newLineRenderer.transform.GetComponentInChildren<LineRendererActivator>().points.Length = 2;
        newLineRenderer.transform.GetChild(1).GetComponent<LineRendererActivator>().points[0] = this.transform;
        newLineRenderer.transform.GetChild(1).GetComponent<LineRendererActivator>().points[1] = touchPos;
    }
    void lockXPosOutofBounds()
    {
        Vector3 newXPos = transform.position;
        if (transform.position.x < -0.25)
        {
            newXPos.x = -0.25f;
        }
        if (transform.position.x > 0.25)
        {
            newXPos.x = 0.25f;
        }
        transform.position = newXPos;
    }

    IEnumerator ChangeCameraFOV()
    {
        changeCameraFOVOnce = true;
        yield return new WaitForSeconds(2f);
        changeCameraFOVOnce = false;
    }
}
