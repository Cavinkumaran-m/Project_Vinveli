using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    Transform target;
    public float smoothness = 0.1f;
    public float mapSize = 41;
    Vector3 targetPos, cameraPos, movement;
    float screenRatio, adjustment, widthOrtho;

    void Start() {
        //Checking left and right screen
        screenRatio = (float)Screen.width / (float)Screen.height;
        widthOrtho = (Camera.main.orthographicSize * screenRatio) + 0.2f;
    }
    void SearchPlayer() {
        if(GameObject.FindWithTag("Player") != null) {
            target = GameObject.FindWithTag("Player").transform;
            return;
        }
    }

    void Update()
    {
        if (target == null)
        {
            SearchPlayer();
            return;
        }
        targetPos = target.position;
        targetPos.z = transform.position.z;
        // cameraPos = transform.position;
        movement = Vector3.Lerp(transform.position, targetPos, smoothness);
        //Checking top and bottom screen
        adjustment = Camera.main.orthographicSize + 0.1f;
        if (movement.y > mapSize - adjustment)
        {
            movement.y = mapSize - adjustment;
        }
        if (movement.y < -mapSize + adjustment)
        {
            movement.y = -mapSize + adjustment;
        }
        
        // Debug.Log(screenRatio);
        if (movement.x > mapSize - widthOrtho)
        {
            movement.x = mapSize - widthOrtho;
        }
        if (movement.x < -mapSize + widthOrtho)
        {
            movement.x = -mapSize + widthOrtho;
        }
        transform.position = movement;

    }
}
