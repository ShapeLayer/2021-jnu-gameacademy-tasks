using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    public GameObject PlayerPrefabDino;
    public GameObject PlayerPrefabSquirrel;
    public GameObject PlayerPrefabDog;
    public GameObject PlayerPrefabSpaceling;

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
            PlayerDino.GetComponent<Transform>().position = new Vector2(0, 3);
        }
        else if (GameManager.instance.CharacterSelect == "Squirrel")
        {
            GameObject PlayerSquirrel = Instantiate(PlayerPrefabSquirrel) as GameObject;
            PlayerSquirrel.GetComponent<Transform>().position = new Vector2(0, 3);
        }
        else if (GameManager.instance.CharacterSelect == "Dog")
        {
            GameObject PlayerDog = Instantiate(PlayerPrefabDog) as GameObject;
            PlayerDog.GetComponent<Transform>().position = new Vector2(0, 3);
        }
        else if (GameManager.instance.CharacterSelect == "Spaceling")
        {
            GameObject PlayerSpaceling = Instantiate(PlayerPrefabSpaceling) as GameObject;
            PlayerSpaceling.GetComponent<Transform>().position = new Vector2(0, 3);
        }
    }
}
