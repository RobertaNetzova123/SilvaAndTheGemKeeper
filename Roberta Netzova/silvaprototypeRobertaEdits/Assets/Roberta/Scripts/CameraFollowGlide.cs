using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowGlide : MonoBehaviour
{
    public Transform followTransform;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, this.transform.position.y, this.transform.position.z);
    }
}