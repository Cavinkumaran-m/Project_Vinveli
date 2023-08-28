using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform Camera;
    public float SpawnInterval = 5f;
    private float SpawnTimer = 5f;
    private Vector3 spawnPoint;
    private int choice;
    
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if(SpawnTimer < 0) {
            choice = Random.Range(0,4);
            switch(choice) {
                case 0:
                    spawnPoint = new Vector3(Camera.position.x + 50, 0, 0);
                    break;
                case 1:
                    spawnPoint = new Vector3(0,Camera.position.x + 50, 0);
                    break;
                case 2:
                    spawnPoint = new Vector3(Camera.position.x - 50, 0, 0);
                    break;
                case 3:
                    spawnPoint = new Vector3(0, Camera.position.y - 50, 0);
                    break;
            }
            Instantiate(enemyPrefab, spawnPoint, Camera.rotation);
            SpawnTimer = SpawnInterval;
            // Debug.Log("Enemy spawned at " + spawnPoint);
        }
    }
}
