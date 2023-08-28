using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float shipRadius = 0.75f;
    public float mapSize = 41;
    // float horizontalInput;
    // float verticalInput;
    Vector3 pos; Vector3 movement;

    private FloatingJoystick joystick;

    void Awake() {
        joystick = GameObject.FindWithTag("joystick1").GetComponent<FloatingJoystick>();
    }

    void Update()
    {
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput = Input.GetAxis("Vertical");
        pos = transform.position;
        movement = new Vector3(joystick.Horizontal, joystick.Vertical, 0f) * moveSpeed * Time.deltaTime;
        // movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        pos += movement;
        //Checking top and bottom screen
        if (pos.y + shipRadius > 41)
        {
            pos.y = 41 - shipRadius;
        }
        if (pos.y - shipRadius < -41)
        {
            pos.y = -41 + shipRadius;
        }

        //Checking left and right screen
        if (pos.x + shipRadius > 41)
        {
            pos.x = 41 - shipRadius;
        }
        if (pos.x - shipRadius < -41)
        {
            pos.x = -41 + shipRadius;
        }

        transform.position = pos;
    }
    
}
