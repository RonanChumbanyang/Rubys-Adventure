//Ronan Chumbanyang's script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float rotationSpeed;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {
        //transform.position = new Vector2(Mathf.Sin(Time.time * freq) * amp + initPos.x, transform.position.y);

        transform.Rotate(0, 0, rotationSpeed);

        if (transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }


    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Enemy e = other.collider.GetComponent<Enemy>();


        if (e != null)
        {
            e.Fix();
        }
        
        Destroy(gameObject);
    }
}
