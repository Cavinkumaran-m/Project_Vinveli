using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float rotSpeed = 90f;
    public float targetRange = 10f;
    public float targetAngle = 20f;
    Transform player;
    private EnemyShooting enemyShooting;
    float temp;
    Vector3 temp2;

    void Start() {
        enemyShooting = FindObjectOfType<EnemyShooting>();
    }

    void Update()
    {
        //forward movement
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
        //================

        //faces to the direction of player
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player == null)
        {
            return;
        }
        Vector3 dir = player.position - transform.position;
        temp2 = dir;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        temp = Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, desiredRot.eulerAngles.z));
        if(temp2.x < targetRange && temp2.x > -targetRange && temp2.y < targetRange && temp2.y > -targetRange && temp < targetAngle) {
            enemyShooting.doShoot = true;
        }
        else {
            enemyShooting.doShoot = false;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
        //==================================


    }
}
