using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_Canon : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemiesParent;
    public bool isSideCanon = false;

    private Stairs_LevelParameters levelParameters;
    private int randWaitTime;

    private void Start()
    {
        levelParameters = FindObjectOfType<Stairs_LevelParameters>();
        randWaitTime = 0;
        StartCoroutine(CreateEnemy());
    }
    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(randWaitTime);
        GameObject newEnemy = Instantiate(enemy, transform.GetChild(0).position, Quaternion.identity).gameObject;
        if(isSideCanon)
            newEnemy.transform.localScale = new Vector3(3f, 3f, 3f);
        //newEnemy.name = enemy;
        newEnemy.transform.parent = enemiesParent;
        randWaitTime = Random.Range(0,5);
        StartCoroutine(CreateEnemy());

    }
}
