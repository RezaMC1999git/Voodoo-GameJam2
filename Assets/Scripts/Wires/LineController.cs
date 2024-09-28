using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform[] points;
    private LineController lineController;

    private void Awake()
    {
        lineController = GetComponent<LineController>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetUpLines(Transform[] points)
    {
        lineRenderer.positionCount = points.Length;
        this.points = points;
    }
    private void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }

    public Vector3[] GetPositions()
    {
        Vector3[] positions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);
        return positions;
    }

    public float getWidth()
    {
        return lineRenderer.startWidth;
    }
}
