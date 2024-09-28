using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaGon_Ball : MonoBehaviour
{
    public GameObject restartPanel;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            restartPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        //if(other.collider)
        if (obj.CompareTag("Bomb"))
        {
            Vector3 dir = other.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().velocity = dir * 2f;
        }
    }
}
