using UnityEngine;

public class BallFight_DoubleTapArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Player>())
        {
            obj.GetComponent<BallFight_Player>().isInsideDoubleTapArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.GetComponent<BallFight_Player>())
        {
            obj.GetComponent<BallFight_Player>().isInsideDoubleTapArea = false;
        }
    }
}
