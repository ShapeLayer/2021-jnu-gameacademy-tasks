using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileControl : MonoBehaviour
{

    public float waitingTime;

    float time;
    public float _fadeTime = 2f;

    void Start()
    {
       
    }



    void Update()
    {
        /*
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
        */
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject, waitingTime);
    }
}
