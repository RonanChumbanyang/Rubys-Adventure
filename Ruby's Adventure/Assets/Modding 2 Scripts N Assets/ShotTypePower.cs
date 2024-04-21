//Ronan Chumbanyang's script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotTypePower : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 lookDirection = new Vector2(1, 0);
    public GameObject projectilePrefabNEW;

    public Slider meter;
    public GameObject meterUIs;
    public AudioSource newShootingSound;

    void Start()
    {
        rigidbody2d = transform.parent.GetComponent<Rigidbody2D>();
        newShootingSound = gameObject.GetComponent<AudioSource>();

    }
    private void OnEnable()
    {
        meterUIs.SetActive(true);
        meter.value = 5;
    }


    void Update()
    {
        if (gameObject.activeSelf)
        {

            StartCoroutine(Countdown());
            

        }

        if (meter.value > 0)
        {
            meter.value -= Time.deltaTime;

        }



        if (Input.GetKeyDown(KeyCode.C))
        {
            LaunchProjectile();
            newShootingSound.PlayOneShot(newShootingSound.clip);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
    }

    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefabNEW, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        NewProjectile projectile = projectileObject.GetComponent<NewProjectile>();
        projectile.Launch(lookDirection, 300);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        meterUIs.SetActive(false);
        StopCoroutine(Countdown());
        gameObject.SetActive(false);
        
    }
    /*IEnumerator StartMeter()
    {
        meterUIs.SetActive(true);
        meter.value = 5;
        while (meter.value > 0)
        {
            meter.value -=  Time.deltaTime;
            
        }
        
    }*/
}
