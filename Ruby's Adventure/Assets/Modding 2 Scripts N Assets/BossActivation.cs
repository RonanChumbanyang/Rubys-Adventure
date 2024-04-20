using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    [Header ("Starting")]
    public GameObject bossUI;
    public GameObject bulletSpawner;
    public AudioClip bossMusic;
    public AudioSource backgroundAudio;

    [Header("ending")]
    public GameObject winUI;
    public GameObject menuPanel;

    BossHealth getBoss;

    private void Start()
    {
        getBoss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
    }

    private void Update()
    {
        if (getBoss.currentHealth <= 0)
        {
            backgroundAudio.Stop();
            bossUI.SetActive(false);
            winUI.SetActive(true);
            StartCoroutine(showMenu());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            getBoss.GetComponent<Collider2D>().enabled = true;
            bossUI.SetActive(true);
            bulletSpawner.SetActive(true);
            //backgroundAudio.volume = 0.5f;
            backgroundAudio.clip = bossMusic;
            backgroundAudio.Play();
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }

    IEnumerator showMenu()
    {
        yield return new WaitForSeconds(4f);
        menuPanel.SetActive(true);
    }
}
