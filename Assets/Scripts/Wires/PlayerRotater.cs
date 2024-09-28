using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotater : MonoBehaviour
{
    Transform ball;
    private void Start()
    {
        ball = transform.GetChild(0).transform;
    }
    private void Update()
    {
        ball.Rotate(1f, 0f, 1f);
    }
}
