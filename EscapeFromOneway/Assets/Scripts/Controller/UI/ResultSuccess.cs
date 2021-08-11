using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSuccess : MonoBehaviour
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
        if (GameManager.instance.GameResult == "Success")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
