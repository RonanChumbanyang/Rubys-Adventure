using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour 
{
    RubyController getRuby;


    private void Start()
    {
        getRuby = GameObject.FindGameObjectWithTag("Player").GetComponent<RubyController>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            getRuby.LosingHealth();
            controller.ChangeHealth(-1);
        }
    }
}
