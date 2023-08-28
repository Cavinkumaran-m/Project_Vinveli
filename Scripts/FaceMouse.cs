using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{

    public float rotationSpeed = 5f;
    private Quaternion targetRotation;

    private Joystick joystick;

    void Start() {
        joystick = GameObject.FindWithTag("joystick2").GetComponent<FloatingJoystick>();
    }

    void Update()
    {
        // Vector3 mousePosition = Input.mousePosition;
        // mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Vector2 direction = new Vector2(
        //     mousePosition.x - transform.position.x,
        //     mousePosition.y - transform.position.y
        // ).normalized;

        if(joystick.Horizontal != 0 || joystick.Vertical != 0) {
            Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);

            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0f, 0f, targetAngle - 90f);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
            
    }

}
