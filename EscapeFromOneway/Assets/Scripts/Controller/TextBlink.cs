using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlick : MonoBehaviour
{

    public GameObject readText;
    // public static GameTextControl instance;

    /*
void Awake()
{
    if (GameTextControl.instance == null)
        GameTextControl.instance = this;
}
*/


    void Start()
    {
        readText.SetActive(false);
        StartCoroutine(ShowReady());
    }

    IEnumerator ShowReady()
    {
        int count = 0;
        while (count < 3)
        {
            readText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            readText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }

    void Update()
    {
        
    }
}
