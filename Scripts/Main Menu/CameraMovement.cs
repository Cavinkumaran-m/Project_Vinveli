using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    int vertical = -1, horizontal = -1;
    public float mapSize = 5f;
    float screenRatio,widthOrtho;


    void Start() {
        screenRatio = (float)Screen.width / (float)Screen.height;
        widthOrtho = (Camera.main.orthographicSize * screenRatio);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)(transform.position.x + Time.deltaTime/2 * horizontal), (float)(transform.position.y + Time.deltaTime/2 * vertical));
        if(transform.position.y > mapSize) {
            vertical = -1;
        }
        if(transform.position.y < -mapSize) {
            vertical = 1;
        }

        
        if(transform.position.x > mapSize  - widthOrtho) {
            horizontal = -1;
        }
        if(transform.position.x < -mapSize  + widthOrtho) {
            horizontal = 1;
        }

    }
}
