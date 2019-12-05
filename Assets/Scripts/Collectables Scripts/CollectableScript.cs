using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DestroyCollectable", 6f);
        // call function DestroyCollectable after 6 seconds
        // if we do not collect coin then deactivate it after 6 seconds
    }

    void DestroyCollectable()
    {
        gameObject.SetActive(false);
    }
}
