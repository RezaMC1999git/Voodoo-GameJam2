using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        switch (gameObject.tag)
        {
            case "3X":
                if (obj.GetComponent<Ball>() != null)
                {
                    if(obj.GetComponent<Ball>().canBeCloned)
                        Create3Clones(obj);
                }
                break;
            case "2X":
                if (obj.GetComponent<Ball>() != null)
                {
                    if (obj.GetComponent<Ball>().canBeCloned)
                        Create2Clones(obj);
                }
                break;
        }
    }
    void Create3Clones(GameObject obj) 
    {
        for(int i = 0; i < 3; i++)
        {
            Vector3 newObjTransform = FindClonePos(obj);
            GameObject newBall =  Instantiate(obj, newObjTransform, Quaternion.identity);
            newBall.GetComponent<Ball>().canBeCloned = false;
        }
    }
    void Create2Clones(GameObject obj)
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 newObjTransform = FindClonePos(obj);
            GameObject newBall =  Instantiate(obj, newObjTransform, Quaternion.identity);
            newBall.GetComponent<Ball>().canBeCloned = false;
        }
    }
    Vector3 FindClonePos(GameObject obj)
    {
        float currentX = obj.transform.position.x;
        float currentZ = obj.transform.position.z;
        Vector3 transformToReturn = new Vector3(0f, obj.transform.position.y, 0f);
        transformToReturn.x = Random.Range(currentX - 1.5f, currentX + 1.5f);
        transformToReturn.z = Random.Range(currentZ - 1.5f, currentZ + 1.5f);
        return transformToReturn;
    }
}
