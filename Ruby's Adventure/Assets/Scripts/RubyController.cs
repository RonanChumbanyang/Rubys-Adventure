﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyController : MonoBehaviour
{
    public float speed = 4;
    
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;
    
    public GameObject projectilePrefab;

    public AudioClip hitSound;
    public AudioClip shootingSound;
    
    public int health
    {
        get { return currentHealth; }
    }
    
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;
    
    int currentHealth;
    float invincibleTimer;
    bool isInvincible;
   
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    
    AudioSource audioSource;


    //MODDING
    public GameObject losePanel;
    private int preHealth;
    public ParticleSystem healingParticle = null;
    public ParticleSystem damagedParticle = null;
    public float defaultSpeed;

    void Start()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();
                
        invincibleTimer = -1.0f;
        currentHealth = maxHealth;
        
        animator = GetComponent<Animator>();
        
        audioSource = GetComponent<AudioSource>();


        defaultSpeed = speed;
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
                
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        currentInput = move;

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.C))
            LaunchProjectile();
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.GetComponent<AudioSource>().Play();
                    character.DisplayDialog();
                }  
            }
        }



        //MODDING
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            losePanel.SetActive(true);
        }
 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        
        position = position + currentInput * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        { 
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(hitSound);

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        /*if(currentHealth == 0)
            Respawn();*/
        
        UIHealthBar.Instance.SetValue(currentHealth / (float)maxHealth);
    }
    
    void Respawn()
    {
        ChangeHealth(maxHealth);
        transform.position = respawnPosition.position;
    }
    
    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        
        animator.SetTrigger("Launch");
        audioSource.PlayOneShot(shootingSound);
    }
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



    

    //MODDING
    public void LosingHealth()
    {
        var em = damagedParticle.emission;
        em.enabled = true;
        damagedParticle.Play();
    }
    public void GainingHealth()
    {
        var em = healingParticle.emission;
        em.enabled = true;
        healingParticle.Play();
        
    }

    private void OnParticleCollision(GameObject other)
    {
        //BossProjectileOne getBoss = other.gameObject.transform.parent.GetComponent<BossProjectileOne>();
        if (other.gameObject.transform.parent.tag == "bullet")
        {
            ChangeHealth(-1);
        }
    }
}
