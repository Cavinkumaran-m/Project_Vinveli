using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Camera;

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Camera.position.x, Camera.position.y, transform.position.z);
    }
}
