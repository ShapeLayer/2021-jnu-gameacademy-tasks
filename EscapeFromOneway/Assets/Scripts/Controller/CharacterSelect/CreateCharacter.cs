using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacter : MonoBehaviour
{
    public GameObject PlayerPrefabDinoidle;
    public GameObject PlayerPrefabSquirrelidle;
    public GameObject PlayerPrefabDogidle;
    public GameObject PlayerPrefabSpacelingidle;

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
        else if (GameManager.instance.CharacterSelect == "Dog")
        {
            GameObject DogCharacter = Instantiate(PlayerPrefabDogidle) as GameObject;
            DogCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
        }
        else if (GameManager.instance.CharacterSelect == "Spaceling")
        {
            GameObject SpacelingCharacter = Instantiate(PlayerPrefabSpacelingidle) as GameObject;
            SpacelingCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}
