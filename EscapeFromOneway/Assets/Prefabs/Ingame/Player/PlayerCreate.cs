using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    public GameObject PlayerPrefabDino;
    public GameObject PlayerPrefabSquirrel;

    void Start()
    {
        CreatePlayer();
    }



    void Update()
    {
        
    }

    public void CreatePlayer()
    {
        if (GameManager.instance.CharacterSelect == "Dino")
        {
            GameObject PlayerDino = Instantiate(PlayerPrefabDino) as GameObject;
            PlayerDino.GetComponent<Transform>().position = new Vector2(0, 0);
        }
        else if (GameManager.instance.CharacterSelect == "Squirrel")
        {
            GameObject PlayerSquirrel = Instantiate(PlayerPrefabSquirrel) as GameObject;
            PlayerSquirrel.GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}
