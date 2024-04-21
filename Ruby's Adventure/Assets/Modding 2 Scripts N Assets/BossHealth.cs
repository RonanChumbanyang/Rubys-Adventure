//Ronan Chumbanyang's script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Sprite bossSecondSprite;

    private AudioSource audioSource;
    public float currentHealth;
    int objNum = 0;
    private Animator animator;

    private bool runOne;
    private bool runTwo;
    private bool runThree;

    void Start()
    {
        currentHealth = 100;
        audioSource = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        healthSlider.value = currentHealth;


        if (currentHealth < 75 && runOne == false)
        {
            objNum++;
            transform.GetChild(objNum).gameObject.SetActive(true);
            runOne = true;
        }
        else if (currentHealth < 50 && currentHealth > 25 && runTwo == false)
        {
            objNum++;
            transform.GetChild(objNum).gameObject.SetActive(true);
            runTwo = true;
        }
        else if (currentHealth <= 25 && currentHealth > 0 && runThree == false)
        {
            objNum++;
            transform.GetChild(objNum).gameObject.SetActive(true);
            runThree = true;
        }
        else if (currentHealth <= 0)
        {
            foreach(Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
                Destroy(animator);
                gameObject.GetComponent<SpriteRenderer>().sprite = bossSecondSprite;
                audioSource.Play();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        NewProjectile newProjectile = collision.gameObject.GetComponent<NewProjectile>();

        if(projectile != null || newProjectile != null)
        {
            currentHealth -= 1.5f;
        }
    }
}
