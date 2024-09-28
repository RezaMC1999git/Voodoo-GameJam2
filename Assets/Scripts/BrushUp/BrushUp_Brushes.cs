using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushUp_Brushes : MonoBehaviour
{
    public float rotateSpeed = 2f;
    void Update()
    {
        transform.Rotate(0f, 0f , 1f * rotateSpeed * Time.deltaTime) ;
    }
}
