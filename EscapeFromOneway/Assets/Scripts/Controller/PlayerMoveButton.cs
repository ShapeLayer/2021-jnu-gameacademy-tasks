using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveButton : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }

    public void ButtonPress()
    {
        switch (this.gameObject.name)
        {
            case "LeftButton":
                GameManager.instance.playerBridgeController.Move(-1);
                break;
            case "UpButton":
                GameManager.instance.playerBridgeController.Move(0);
                break;
            case "RightButton":
                GameManager.instance.playerBridgeController.Move(1);
                break;
        }
    }
}
