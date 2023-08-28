using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    private TextMeshProUGUI label;
    public TextMeshProUGUI ChildLabel;
    private GameObject joystick1, joystick2;
    public GameObject pausePanel;

    void Awake() {
        label = ChildLabel.GetComponent<TextMeshProUGUI>();
        joystick1 = GameObject.FindWithTag("joystick1");
        joystick2 = GameObject.FindWithTag("joystick2");
        if(joystick1 == null) {
            Debug.Log("joy null");
        }
    }
    public void PauseGame() {
        if(Time.timeScale == 1) {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            label.text = "P";
            joystick1.SetActive(false);
            joystick2.SetActive(false);
        }
        else {
            pausePanel.SetActive(false);    
            Time.timeScale = 1;
            label.text = "II";
            joystick1.SetActive(true);
            joystick2.SetActive(true);
        }
        
    }
}
