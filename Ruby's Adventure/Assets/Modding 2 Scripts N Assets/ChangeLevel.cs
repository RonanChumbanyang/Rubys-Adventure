//Ronan Chumbanyang's script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public CanvasGroup panel;

    private void Update()
    {
        if (panel.alpha == 1)
        {
            SceneManager.LoadScene("Boss Scene");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Transitioning());
        }
    }

    IEnumerator Transitioning()
    {
        while (panel.alpha <= 1)
        {
            panel.alpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }
}
