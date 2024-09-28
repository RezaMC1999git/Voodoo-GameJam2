using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFight_WinCollider : MonoBehaviour
{
    public GameObject winPanel;
    public Animator enemyAnimator;
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Player>())
        {
            int chance = Random.Range(0, 10);
            if (chance >=0 && chance <= 6)
            {
                StartCoroutine(Dodge());
            }
            if(chance >6 && chance <=9)
                StartCoroutine(WinLevel());
        }
    }

    private IEnumerator Dodge()
    {
        GetComponentInParent<BallFight_Enemy>().isAlive = false;
        Vector3 dodge = enemyAnimator.transform.position;
        int leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
            enemyAnimator.GetComponent<Rigidbody>().velocity = new Vector3(30f, 0f, 0f);
            //dodge.x += Random.Range(16f, 22f);
        if (leftOrRight == 1)
            enemyAnimator.GetComponent<Rigidbody>().velocity = new Vector3(-30f, 0f, 0f);
            //dodge.x -= Random.Range(16f, 22f);
        enemyAnimator.transform.position = Vector3.MoveTowards(enemyAnimator.transform.position, dodge,
            70f * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        GetComponentInParent<BallFight_Enemy>().isAlive = true;
    }

    private IEnumerator WinLevel()
    {
        GetComponentInParent<BallFight_Enemy>().isAlive = false;
        enemyAnimator.enabled = true;
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }
}
