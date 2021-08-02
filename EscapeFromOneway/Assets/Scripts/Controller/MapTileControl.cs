using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileControl : MonoBehaviour
{

    public float waitingTime;

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
}
