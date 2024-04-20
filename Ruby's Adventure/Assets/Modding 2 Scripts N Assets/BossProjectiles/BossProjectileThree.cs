using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileThree : MonoBehaviour
{
    //[Header ("Pat 1 Settings")]
    public int columnNum;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    public Material material;
    public float rotateSpeed;
    public float duration;
    public int sortOrder;
    public ParticleSystemShapeType shapeTypeVar;

    /*[Header("Pat 2 Settings")]
    public int columnNumTwo;
    public float speedTwo;
    public Sprite textureTwo;
    public Color colorTwo;
    public float lifetimeTwo;
    public float firerateTwo;
    public float sizeTwo;
    public Material materialTwo;
    public float rotateSpeedTwo;
    public float durationTwo;
    public int sortOrderTwo;
    public ParticleSystemShapeType shapeTypeVarTwo;
    */
    private float angle;
    private float time;

    public ParticleSystem system;


    private void Awake()
    {
        PatOne();

    }

    private void Update()
    {
        /*var health = gameObject.GetComponentInParent<BossHealth>().currentHealth;



        if (health > 75 && runOne == false)
        {
            PatOne();
            runOne = true;

        }
        else if (health <= 75 && health > 50 && runTwo == false)
        {
            Debug.Log("Two");
            runTwo = true;
        }*/
    }

    private void FixedUpdate()
    {

        /*var health = gameObject.GetComponentInParent<BossHealth>().currentHealth;



        if (health > 75 && runOne == false)
        {
            
            PatOne();
            runOne = true;
            
        }
        else if (health <= 75 && health > 50 && runTwo == false)
        {
            
            var system = gameObject.GetComponentsInChildren<ParticleSystem>();
            for(int i =0; i< system.Length; i++)
            {
                Destroy(system[i].gameObject);
            }
            
            PatTwo();
            rotateSpeed = rotateSpeedTwo;
            runTwo = true;
        }
        */



        time += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, time * rotateSpeed);

    }



    void PatOne()
    {
        angle = 360f / columnNum;
        for (int i = 0; i < columnNum; i++)
        {

            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.

            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;


            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;
            mainModule.maxParticles = 100000;
            
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            

            var emission = system.emission;
            emission.enabled = false;

            var shape = system.shape;
            shape.enabled = true;
            shape.shapeType = shapeTypeVar;
            shape.sprite = null;

            var textureSheet = system.textureSheetAnimation;
            textureSheet.mode = ParticleSystemAnimationMode.Sprites;
            textureSheet.AddSprite(texture);
            textureSheet.enabled = true;


            //collision
            var collision = system.collision;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.lifetimeLoss = 1;
            collision.collidesWith = LayerMask.GetMask("player");
            collision.sendCollisionMessages = true;
            collision.enabled = true;


            var getRenderer = system.GetComponent<ParticleSystemRenderer>();
            getRenderer.sortingOrder = sortOrder;

            
        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate);

    }

    /*void PatTwo()
    {
        angle = 360f / columnNumTwo;
        for (int i = 0; i < columnNumTwo; i++)
        {

            // A simple particle material with no texture.
            Material particleMaterial = materialTwo;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.

            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;


            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speedTwo;
            mainModule.maxParticles = 100000;

            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;



            var emission = system.emission;
            emission.enabled = false;

            var shape = system.shape;
            shape.enabled = true;
            shape.shapeType = shapeTypeVarTwo;
            shape.sprite = null;

            var textureSheet = system.textureSheetAnimation;
            textureSheet.mode = ParticleSystemAnimationMode.Sprites;
            textureSheet.AddSprite(textureTwo);
            textureSheet.enabled = true;


            //collision
            var collision = system.collision;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.lifetimeLoss = 1;
            collision.collidesWith = LayerMask.GetMask("player");
            collision.sendCollisionMessages = true;
            collision.enabled = true;


            var getRenderer = system.GetComponent<ParticleSystemRenderer>();
            getRenderer.sortingOrder = sortOrderTwo;


        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmitTwo", 0f, firerateTwo);
    }*/

    void DoEmit()
    {
        foreach (Transform child in transform)
        {

                system = child.GetComponent<ParticleSystem>();
                // Any parameters we assign in emitParams will override the current system's when we call Emit.
                // Here we will override the start color and size.
                var emitParams = new ParticleSystem.EmitParams();
                emitParams.startColor = color;
                emitParams.startSize = size;
                emitParams.startLifetime = lifetime;
                system.Emit(emitParams, 10);
            
        }
    }

    /*void DoEmitTwo()
    {
        foreach (Transform child in transform)
        {

            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
            emitParams.startColor = color;
            emitParams.startSize = size;
            emitParams.startLifetime = lifetime;
            system.Emit(emitParams, 10);

        }
    }*/

}
