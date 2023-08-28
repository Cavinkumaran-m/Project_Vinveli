using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreGUI : MonoBehaviour
{
    private HighScoreManager highScoreManager;
    private TextMeshProUGUI label;

    // Start is called before the first frame update
    void Start()
    {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        label = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        label.text = "Game Over\nYour Score : " + highScoreManager.currentScore + "\n Highest Score : " + highScoreManager.highScore + "\nRestarting Game";
    }
}
