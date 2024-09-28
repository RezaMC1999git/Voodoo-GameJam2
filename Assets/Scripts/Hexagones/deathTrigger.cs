using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Player"))
            Application.LoadLevel(Application.loadedLevel);
        if (obj.tag == "YellowHex" || obj.tag == "WhiteHex" || obj.tag == "RedHex" ||
            obj.tag == "BlueHex" || obj.tag == "OrangeHex" || obj.tag == "Hexagone")
            Destroy(obj);
    }
}
