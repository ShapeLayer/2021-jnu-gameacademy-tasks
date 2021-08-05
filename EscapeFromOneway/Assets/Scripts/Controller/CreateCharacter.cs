using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    public GameObject PlayerPrefabDinoidle;
    public GameObject PlayerPrefabSquirrelidle;

    void Start()
    {
        CharacterCreate();
    }


    void Update()
    {
        
    }

    public void CharacterCreate()
    {
        if (GameManager.instance.CharacterSelect == "Dino")
        {
            GameObject DinoCharacter = Instantiate(PlayerPrefabDinoidle) as GameObject;
            DinoCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
        }
        else if (GameManager.instance.CharacterSelect == "Squirrel")
        {
            GameObject SquirrelCharacter = Instantiate(PlayerPrefabSquirrelidle) as GameObject;
            SquirrelCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}
