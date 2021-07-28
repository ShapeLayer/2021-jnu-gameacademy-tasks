using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "ModeChangeButton":
                SceneManager.LoadScene("ModeChangeUI");
                break;
            case "PlayButton":
                SceneManager.LoadScene("IngameUI");
                break;
            case "CharacterSelectButton":
                SceneManager.LoadScene("CharacterSelectUI");
                break;
        }
    }
}
