using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectButton : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void CharacterChangeScene()
    {
        switch(this.gameObject.name)
        {
            case "SelectButton":
                {
                    if (GameObject.Find("idle_down_Squirrel(Clone)"))
                    {
                        GameManager.instance.CharacterSelect = "Squirrel";
                    }
                    else if (GameObject.Find("idle_down_Dino(Clone)"))
                    {
                        GameManager.instance.CharacterSelect = "Dino";
                    }
                    else if (GameObject.Find("idle_down_Dog(Clone)"))
                    {
                        GameManager.instance.CharacterSelect = "Dog";
                    }
                    else if (GameObject.Find("idle_down_Spaceling(Clone)"))
                    {
                        GameManager.instance.CharacterSelect = "Spaceling";
                    }
                    SceneManager.LoadScene("StageLobbyUI");
                    break;
                }
        }
    }
}
