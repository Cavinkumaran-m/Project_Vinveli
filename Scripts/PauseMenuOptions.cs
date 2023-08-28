using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuOptions : MonoBehaviour
{
    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit() {
        Application.Quit();
    }
}
