using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonActions : MonoBehaviour
{
    public GameObject screen;
    private FadeOutAnime fader;
    // private Animator _animator;
    Color tmp; 

    void Awake() {
        // _animator = GetComponent<Animator>();
        fader = FindObjectOfType<FadeOutAnime>();
        tmp = screen.GetComponent<SpriteRenderer>().color;
        // if(_animator == null) {
        //     Debug.Log("Animator is not assigned !!");
        // }
        // tmp.a = 0f;
        // Debug.Log(screen.GetComponent<SpriteRenderer>().color.a);
    }



    public void playGame() {
        fader.Animation();
    }

    public void quitGame() {
        Application.Quit();
    }
}
