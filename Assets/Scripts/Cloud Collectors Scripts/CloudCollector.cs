using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Cloud" || target.tag == "Deadly")
        {
            target.gameObject.SetActive(false);
        }
    }
}
