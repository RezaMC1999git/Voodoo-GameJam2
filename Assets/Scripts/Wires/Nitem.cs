using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player"))
        {
            Vector3 objScale = obj.transform.localScale;
            objScale.x -= 0.005f;
            objScale.y -= 0.005f;
            objScale.z -= 0.005f;
            obj.transform.localScale = objScale;
            Destroy(gameObject);
        }
    }
}
