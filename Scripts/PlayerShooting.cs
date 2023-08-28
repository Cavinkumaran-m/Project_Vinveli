using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireDelay = 0.1f;
    float coolDownTimer = 0;
    public Vector3 BulletOffset = new Vector3(0, 0.5f, 0);
    private Joystick joystick;
    public float DeadZone = 0.2f;
    public AudioSource bulletAudio;

    void Start() {
        joystick = GameObject.FindWithTag("joystick2").GetComponent<FloatingJoystick>();
        // bulletAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        coolDownTimer -= Time.deltaTime;
        if((joystick.Horizontal > DeadZone || joystick.Vertical > DeadZone || joystick.Horizontal < -DeadZone || joystick.Vertical < -DeadZone) && coolDownTimer <= 0 && Time.timeScale == 1)
        {
            bulletAudio.Play();
            coolDownTimer = fireDelay;
            Vector3 offset = transform.rotation * BulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
