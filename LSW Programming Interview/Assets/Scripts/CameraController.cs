using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        //Change camera position based on target position----------------------------------------------------------------
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

    }
}
