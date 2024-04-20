using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSlowScript : MonoBehaviour
{
    RubyController controller;
    public GameObject slowUIText;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<RubyController>();
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
