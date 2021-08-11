using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacterChangeButton : MonoBehaviour
{
    public GameObject PlayerPrefabDinoidle;
    public GameObject PlayerPrefabSquirrelidle;
    public GameObject PlayerPrefabDogidle;
    public GameObject PlayerPrefabSpacelingidle;

    void Start()
    {

    }

   
    void Update()
    {
        
    }


    public void ChangeCharacterScene()   //캐릭터 선택화면
    {
        switch (this.gameObject.name)
        {
            case "LeftButton":
                {

                    if(GameObject.Find("idle_down_Dino(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Dino(Clone)"));
                        GameObject SpacelingCharacter = Instantiate(PlayerPrefabSpacelingidle) as GameObject;
                        SpacelingCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    else if (GameObject.Find("idle_down_Squirrel(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Squirrel(Clone)"));
                        GameObject DinoCharacter = Instantiate(PlayerPrefabDinoidle) as GameObject;
                        DinoCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    else if (GameObject.Find("idle_down_Dog(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Dog(Clone)"));
                        GameObject SquirrelCharacter = Instantiate(PlayerPrefabSquirrelidle) as GameObject;
                        SquirrelCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    else if (GameObject.Find("idle_down_Spaceling(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Spaceling(Clone)"));
                        GameObject DogCharacter = Instantiate(PlayerPrefabDogidle) as GameObject;
                        DogCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    break;
                }
            case "RightButton":
                {
                   
                    if (GameObject.Find("idle_down_Dino(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Dino(Clone)"));
                        GameObject SquirrelCharacter = Instantiate(PlayerPrefabSquirrelidle) as GameObject;
                        SquirrelCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    else if (GameObject.Find("idle_down_Squirrel(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Squirrel(Clone)"));
                        GameObject DogCharacter = Instantiate(PlayerPrefabDogidle) as GameObject;
                        DogCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    else if (GameObject.Find("idle_down_Dog(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Dog(Clone)"));
                        GameObject SpacelingCharacter = Instantiate(PlayerPrefabSpacelingidle) as GameObject;
                        SpacelingCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    else if (GameObject.Find("idle_down_Spaceling(Clone)"))
                    {
                        Destroy(GameObject.Find("idle_down_Spaceling(Clone)"));
                        GameObject DinoCharacter = Instantiate(PlayerPrefabDinoidle) as GameObject;
                        DinoCharacter.GetComponent<Transform>().position = new Vector2(0, 0);
                    }
                    break;
                }


        }
    }
}
