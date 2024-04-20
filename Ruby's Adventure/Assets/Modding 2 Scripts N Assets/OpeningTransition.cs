using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningTransition : MonoBehaviour
{
    public CanvasGroup panel;

    void Start()
    {
        StartCoroutine(Transitioning());
    }


    void Update()
    {
        //panel = gameObject.GetComponent<CanvasGroup>();
    }

    IEnumerator Transitioning()
    {
        while (panel.alpha > 0)
        {
            panel.alpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }
}
