using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour 
{
    public int healAmount;

    RubyController getRuby;

    private void Start()
    {
        getRuby = GameObject.FindGameObjectWithTag("Player").GetComponent<RubyController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(healAmount);
            getRuby.GainingHealth();
            Destroy(gameObject);
            
        }
    }
}
