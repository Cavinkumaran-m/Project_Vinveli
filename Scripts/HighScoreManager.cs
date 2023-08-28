using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public int highScore, currentScore = 0;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    public void UpdateHighScore()
    {
        if(currentScore > highScore) {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    public void UpdateCurrentScore()
    {
        currentScore += 1;
    }
}
