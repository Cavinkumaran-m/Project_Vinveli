using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesGUI : MonoBehaviour
{
    private PlayerSpawner playerSpawner;
    private TextMeshProUGUI label;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        // Debug.Log(playerSpawner.lives);
        label = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSpawner.lives == -1) {
            label.text = "Game Over";
            return;
        }
        label.text = "Lives : " + playerSpawner.lives;
    }
}
