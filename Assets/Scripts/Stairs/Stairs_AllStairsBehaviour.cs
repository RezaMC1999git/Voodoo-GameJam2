using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs_AllStairsBehaviour : MonoBehaviour
{
    public List<GameObject> allStairs;
    private void Update()
    {
        DisableCorrectStair();
    }
    void DisableCorrectStair()
    {
        for(int i=0;i<allStairs.Count;i++)
        {
            if (allStairs[i].GetComponent<Stairs_Stair>().activated)
            {
                StartCoroutine(DisableBoxColider(allStairs[i + 1]));      
            }
        }
    }
    IEnumerator DisableBoxColider(GameObject stair)
    {
        stair.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        stair.GetComponent<BoxCollider>().enabled = true;
    }
}
