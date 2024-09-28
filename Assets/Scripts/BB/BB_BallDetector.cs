using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_BallDetector : MonoBehaviour
{
    public GameObject[] subMatts;
    public BoxCollider parentBoxCollider;

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player"))
        {
            if (obj.GetComponent<BB_Player>().ballComeDownWeGotHeadache)
            {
                parentBoxCollider.enabled = false;
                GetComponentInParent<Animator>().enabled = true;
                FindObjectOfType<BB_GameController>().MattCollected();
                StartCoroutine(TurnOffAnimator());
            }
        }
    }
    IEnumerator TurnOffAnimator()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject subMatt in subMatts)
        {
            subMatt.GetComponent<Rigidbody>().isKinematic = false;
        }
        GetComponentInParent<Animator>().enabled = false;
        yield return new WaitForSeconds(1f);
        parentBoxCollider.GetComponent<BB_Matt>().splittedAway = true;
    }
}
