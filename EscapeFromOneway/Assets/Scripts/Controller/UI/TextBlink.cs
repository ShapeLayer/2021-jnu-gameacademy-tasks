using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBlink : MonoBehaviour
{

    public float aValue = 1;
    private CanvasGroup trans;

    void Start()
    {
        trans = GetComponent<CanvasGroup>();
        trans.alpha = aValue;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            trans.alpha = 1;
            yield return new WaitForSeconds(0.5f);
            trans.alpha = 0;
            yield return new WaitForSeconds(0.5f);;
        }
    }

    void Update()
    {
        
    }
}
