using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultFail : MonoBehaviour
{

    void Start()
    {
        SetActiveResultText();
    }

    void Update()
    {
        
    }

    public void SetActiveResultText()
    {
        if (GameManager.instance.GameResult == "Fail")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
