using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DestroyCollectable", 8f);
        // call function DestroyCollectable after 8 seconds
        // if we do not collect coin then deactivate it after 8 seconds
    }

    void DestroyCollectable()
    {
        gameObject.SetActive(false);
    }
}
