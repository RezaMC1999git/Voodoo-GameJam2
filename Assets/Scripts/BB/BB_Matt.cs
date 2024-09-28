using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Matt : MonoBehaviour
{
    public bool splittedAway = false;
    void Update()
    {
        if (splittedAway)
            Destroy(gameObject);
    }
}
