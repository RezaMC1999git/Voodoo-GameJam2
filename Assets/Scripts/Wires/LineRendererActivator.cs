using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererActivator : MonoBehaviour
{
    public Transform[] points;
    public LineController lineController;

    private void Start()
    {
        lineController.SetUpLines(points);
    }
}
