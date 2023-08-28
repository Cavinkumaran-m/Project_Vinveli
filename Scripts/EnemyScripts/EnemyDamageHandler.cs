using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    public int maxHealth = 5;
    public ParticleSystem burst;
    public AudioSource Impact;
    private ExplosionSoundScript explosionSoundScript;
    private HighScoreManager highScoreManager;
    
    void Start() {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        explosionSoundScript = FindObjectOfType<ExplosionSoundScript>();
    }

    void OnTriggerEnter2D()
    {   
        maxHealth--;
        Impact.Play();
        Instantiate(burst, transform.position,   transform.rotation * Quaternion.Euler (0f, 90f, 90f));
    }

    void Update()
    {
        if (maxHealth <= 0)
        {
            highScoreManager.UpdateCurrentScore();
            explosionSoundScript.playExplosion();
            Destroy(gameObject);
        }
    }
}
