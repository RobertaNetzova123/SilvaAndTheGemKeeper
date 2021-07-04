using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectChange : MonoBehaviour
{
    [System.NonSerialized]
    public bool objectChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject platformTrigger = other.gameObject;
        GameObject pushedObj = this.gameObject;
        if (platformTrigger.layer == LayerMask.NameToLayer("Water"))
        //if (platformTrigger.CompareTag("BoxPlatform"))
        {
            pushedObj.GetComponent<BoxCollider2D>().isTrigger = false;
            objectChanged = true;
        }
    }
}
