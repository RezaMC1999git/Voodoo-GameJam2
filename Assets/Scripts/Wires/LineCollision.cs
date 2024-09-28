using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineCollision))]
public class LineCollision : MonoBehaviour
{
    LineController lineController;
    BoxCollider boxCollider;
    List<Vector3> colliderPoints = new List<Vector3>();
    void Start()
    {
        lineController = GetComponent<LineController>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (colliderPoints != null) colliderPoints.ForEach(p => Gizmos.DrawSphere(p, 0.1f));
    }
    void Update()
    {
        colliderPoints = CallculateColliderPoints();
    }

    List<Vector3> CallculateColliderPoints()
    {
        Vector3[] positions = lineController.GetPositions();
        float width = lineController.getWidth();
        float m = (positions[1].y - positions[0].y / positions[1].x - positions[0].x);
        float deltaX = (width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
        float deltaY = (width / 2f) * (1 / Mathf.Pow(m * m + 1, 0.5f));
        Vector3[] offsets = new Vector3[2];
        offsets[0] = new Vector3(-deltaX, deltaY);
        offsets[1] = new Vector3(deltaX, -deltaY);

        List<Vector3> colliderPositions = new List<Vector3>
        {
            positions[0] + offsets[0],
            positions[1] + offsets[0],
            positions[1] + offsets[1],
            positions[0] + offsets[1],
        };
        return colliderPositions;
    }
}
