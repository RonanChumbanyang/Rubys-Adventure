using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollectible : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.GetChild(3).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
