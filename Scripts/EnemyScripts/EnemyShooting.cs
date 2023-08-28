using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireDelay = 1f;
    float coolDownTimer = 0;
    public Vector3 BulletOffset = new Vector3(0, 0.5f, 0);
    public float rotSpeed = 90f;
    Transform player;
    private AudioSource bulletAudio;
    public bool doShoot = false;
    

    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        coolDownTimer -= Time.deltaTime;
        if (doShoot && coolDownTimer <= 0)
        {
            bulletAudio.Play();
            coolDownTimer = fireDelay;
            Vector3 offset = transform.rotation * BulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
