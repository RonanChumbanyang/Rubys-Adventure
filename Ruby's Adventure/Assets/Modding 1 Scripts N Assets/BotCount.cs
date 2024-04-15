using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotCount : MonoBehaviour
{
    public GameObject[] bots;
    public GameObject menuPanel;

    public Text countText;
    private int count = 0;

    private int repairedCount;

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
        if (count == 0)
        {
            menuPanel.SetActive(true);
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
}
