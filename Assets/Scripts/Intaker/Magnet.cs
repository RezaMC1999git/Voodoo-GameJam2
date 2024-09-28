using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TurnOn());
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.GetComponent<Ball>() != null)
        {
            obj.GetComponent<Rigidbody>().isKinematic = true;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.GetComponent<BallMove>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<Ball>() != null)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<BallMove>().enabled = false;
        }
    }
    IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
