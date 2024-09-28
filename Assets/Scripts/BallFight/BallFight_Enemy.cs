using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallFight_Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public int health = 3;
    public bool isAlive = true;
    public float chaseSpeed = 2f;
    public TextMeshPro healthText;
    public GameObject deathPanelAnimator;
    public GameObject UI;
    public bool isLevel2 = false;

    private void Start()
    {
        if(healthText != null)
            healthText.text = health.ToString();
    }
    void Update()
    {
        if (isAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                playerTransform.position, chaseSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage()
    {
        health--;
        if(health>0)
            healthText.text = health.ToString();
        else
        {
            healthText.gameObject.SetActive(false);
            StartCoroutine(WinLevel());
        }
    }
    private IEnumerator WinLevel()
    {
        deathPanelAnimator.SetActive(true);
        yield return new WaitForSeconds(2f);
        UI.SetActive(true);
        Time.timeScale = 0f;
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Player>())
        {
            if (isLevel2)
            {
                Vector3 dir = other.contacts[0].point - transform.position;
                dir = -dir.normalized;
                GetComponent<Rigidbody>().velocity = dir * 25f;
            }
        }
    }
}
