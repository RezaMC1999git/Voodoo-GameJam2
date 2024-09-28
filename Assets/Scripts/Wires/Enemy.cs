using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Player"))
        {
            Vector3 thisScale = transform.localScale;
            Vector3 objScale = obj.transform.localScale;
            if(objScale.x >= thisScale.x || objScale.y >= thisScale.y || objScale.z >= thisScale.z)
            {
                Destroy(gameObject);
                StartCoroutine(ResetGame());
            }
            else
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(Application.loadedLevel);
    }
}
