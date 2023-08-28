using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public int maxHealth = 5;
    public ParticleSystem burst;
    public AudioSource Impact;
    public float invulnerablePeriod = 5f;
    float invulnerableTimer = 0f;
    bool invulnerableFeature = false;
    public float invulnerableAnimeSpeed = 0.2f;
    float invulnerableAnimeTimer = 0f;
    int correctLayer;
    SpriteRenderer spriteRend;
    private ExplosionSoundScript explosionSoundScript;

    void Start()
    {
        explosionSoundScript = FindObjectOfType<ExplosionSoundScript>();
        if(gameObject.tag == "Player") {
            invulnerableFeature = true;
            correctLayer = gameObject.layer;
            spriteRend = GetComponent<SpriteRenderer>();
            if(spriteRend == null) {
                Debug.LogError("Sprite missing for '" + gameObject.name + "'");
            }
            invulnerableTimer = invulnerablePeriod;
            gameObject.layer = 8;
        } 
    }

    void OnTriggerEnter2D()
    {   maxHealth--;
        Instantiate(burst, transform.position,  transform.rotation * Quaternion.Euler (0f, 90f, 90f));
        if (invulnerablePeriod > 0 && invulnerableFeature)
        {
            Impact.Play();
            invulnerableTimer = invulnerablePeriod;
            gameObject.layer = 8;
        }
    }

    void Update()
    {
        if (invulnerableTimer > 0 && invulnerableFeature)
        {
            invulnerableTimer -= Time.deltaTime;
            if (invulnerableTimer < 0)
            {
                if(spriteRend != null) {
                    spriteRend.enabled = true;
                }
                gameObject.layer = correctLayer;
            }
            else {
                invulnerableAnimeTimer -= Time.deltaTime;
                if(invulnerableAnimeTimer < 0) {
                    if(spriteRend != null) {
                        spriteRend.enabled = !spriteRend.enabled;
                        invulnerableAnimeTimer = invulnerableAnimeSpeed;
                    }
                }
                
            }

            if (maxHealth <= 0)
            {
                explosionSoundScript.playExplosion();
                Destroy(gameObject);
            }   
        }     
    }
}
