using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Stairs_LevelParameters : MonoBehaviour
{
    public GameObject stair;
    public GameObject edge;
    public GameObject winStair;
    public Transform stairsParent;
    public Transform edgesParent;
    public int stairsNumber;

    private Vector3 stairPos;
    private Vector3 edgePos;
    private Vector3 lastStairPos;
    private Stairs_AllStairsBehaviour allStairsBehaviour;

    private void Start()
    {
        allStairsBehaviour = FindObjectOfType<Stairs_AllStairsBehaviour>();
        allStairsBehaviour.allStairs = new List<GameObject>(stairsNumber);
        allStairsBehaviour.allStairs.Add(stair);
        stairPos = stair.transform.position;
        edgePos = edge.transform.position;
        CreateStairs();
    }
    public void CreateStairs()
    {
        for(int i = 0; i < stairsNumber; i++)
        {
            Vector3 newStairPos = new Vector3(stairPos.x, stairPos.y + (9.3f * (i + 1)), stairPos.z + (-25.2f * (i + 1)));
            GameObject newStair = Instantiate(stair, newStairPos, Quaternion.identity).gameObject;
            newStair.name = "stair" + (i + 2);
            newStair.transform.parent = stairsParent;
            allStairsBehaviour.allStairs.Add(newStair);

            Vector3 newEdgePos = new Vector3(edgePos.x, edgePos.y + (9.3f * (i + 1)), edgePos.z + (-25.2f * (i + 1)));
            GameObject newEdge = Instantiate(edge, newEdgePos, Quaternion.Euler(90f,0f,0f)).gameObject;
            newEdge.name = "edge" + (i + 2);
            newEdge.transform.parent = edgesParent;
        }
        lastStairPos.x = stairPos.x;
        lastStairPos.y += stairPos.y + (9.3f * (stairsNumber +1));
        lastStairPos.z += stairPos.z + (-25.2f * (stairsNumber +1));
        GameObject lastStair = Instantiate(winStair, lastStairPos, Quaternion.identity).gameObject;
        FindObjectOfType<Stairs_GameController>().winStair = lastStair;
        lastStair.name = "WinStair";
        lastStair.transform.parent = stairsParent;
    }
}
