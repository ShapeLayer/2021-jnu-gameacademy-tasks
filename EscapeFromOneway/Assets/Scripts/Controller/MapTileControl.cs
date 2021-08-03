using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileControl : MonoBehaviour
{

    public float waitingTime;

    float time = 0;
    public float _fadeTime = 3f;


    void Start()
    {
     
    }



    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject, waitingTime);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (time < _fadeTime)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time / _fadeTime);
        }
        else
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }

}
