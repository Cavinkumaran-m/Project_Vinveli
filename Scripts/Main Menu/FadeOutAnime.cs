using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeOutAnime : MonoBehaviour
{
    private Animator _animator;

    void Awake() {
        _animator = GetComponent<Animator>();
        if(_animator == null) {
            Debug.Log("Animator is not assigned !!");
        }
    }

    public void Animation() {
        StartCoroutine(animator());
    }

    IEnumerator animator() {
        _animator.SetTrigger("OnStartGame");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("SampleScene");
    }
}
