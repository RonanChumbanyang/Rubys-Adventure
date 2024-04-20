using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BotCount : MonoBehaviour
{
    public GameObject[] bots;
    public GameObject menuPanel;

    public Text countText;
    private int count = 0;

    public TMP_Text dialogueTMP;
    public string dialogue;

    public GameObject wall;

    private bool soundPlayed;

    void Start()
    {
        count = bots.Length;

        
    }

    void Update()
    {
        for (int i = 0; i < bots.Length; i++)
        {
            if (bots[i].GetComponent<Enemy>().repaired)
            {
                count = count - 1;
                RemoveAt(ref bots, i);
                break;
            }
            
        }

        countText.text = "Robots left: " + count.ToString();
        AudioSource audioSource;
        if (count == 0 && !soundPlayed)
        {
            
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            soundPlayed = true;
            menuPanel.SetActive(true);
            wall.SetActive(false);
            //StartCoroutine(TypeTextCO());
            
            
        }
        
    }

    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            arr[a] = arr[a + 1];
        }
        System.Array.Resize(ref arr, arr.Length - 1);
    }

    IEnumerator TypeTextCO()
    {
        dialogueTMP.text = "";
        for (int i = 0; i < dialogue.Length; i++)
        {
            dialogueTMP.text += dialogue[i];
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }
}
