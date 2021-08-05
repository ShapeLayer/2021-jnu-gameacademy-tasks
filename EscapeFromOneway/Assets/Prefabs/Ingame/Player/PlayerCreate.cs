using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    public GameObject PlayerPrefab;

    void Start()
    {
        CreatePlayer();
    }



    void Update()
    {
        
    }

    public void CreatePlayer()
    {
        GameObject newObject = Instantiate(PlayerPrefab) as GameObject;
        newObject.GetComponent<Transform>().position = new Vector2(0, 0);
    }
}
