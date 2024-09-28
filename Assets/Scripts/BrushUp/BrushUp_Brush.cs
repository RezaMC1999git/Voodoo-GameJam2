using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrushUp_Brush : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            HandleTouchInputs();
        }
    }

    void HandleTouchInputs()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        if (results.Capacity > 0)
        {
            if (results[0].gameObject.CompareTag("Brush"))
            {
                
            }
        }
    }
}
