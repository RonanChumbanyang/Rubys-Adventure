//Luis Santiago's script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSlowScript : MonoBehaviour
{
    RubyController controller;
    public GameObject slowUIText;
    private AudioSource audioSource;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<RubyController>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            controller.speed = 1;
            slowUIText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        controller = other.GetComponent<RubyController>();
        if (controller != null)
        {
            controller.speed = controller.defaultSpeed;
            slowUIText.SetActive(false);
        }

    }
}
