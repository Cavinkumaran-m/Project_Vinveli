using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSoundScript : MonoBehaviour
{
    public AudioSource explosion;
    public GameObject Camera;
    private Animator anime;
    void Awake() {
        anime = Camera.GetComponent<Animator>();
    }
    
    public void playExplosion() {
        explosion.Play();
        int rand = Random.Range(0,2);
        if(rand == 0) {
            anime.SetTrigger("shake_1");
        }
        else {
            anime.SetTrigger("shake_2");
        }
        
    }  
}
