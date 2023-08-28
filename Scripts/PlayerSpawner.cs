using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;
    float respawnTime;
    public int lives = 3;
    public GameObject GameOverPanel;
    private bool flag;
    private HighScoreManager highScoreManager;

    void Start() {
        flag = true;
        spawnPlayer();
        highScoreManager = FindObjectOfType<HighScoreManager>();
    }

    void spawnPlayer() {
        respawnTime = 1f;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.name = "Player";
    }

    void Update() {
        if(playerInstance == null) {
            respawnTime -= Time.deltaTime;
            if(respawnTime < 0) {
                if(lives == -1 && flag) {
                    flag = false;
                    GameOverPanel.SetActive(true);
                    highScoreManager.UpdateHighScore();
                    StartCoroutine(SleepForSeconds(3f));
                    return;
                }
                if(lives > 0) {
                    lives--;
                    spawnPlayer();
                }
                else {
                    lives = -1;
                }
                
            }
        }
    }

    IEnumerator SleepForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("SampleScene");
    }

}