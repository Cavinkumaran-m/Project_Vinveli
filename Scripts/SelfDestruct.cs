using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float AliveTime = 3f;
    int health = 1;

    void OnTriggerEnter2D()
    {
        health--;
    }

    void Update()
    {
        AliveTime -= Time.deltaTime;
        if (health == 0)
        {
            Destroy(gameObject);
        }
        if (AliveTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
