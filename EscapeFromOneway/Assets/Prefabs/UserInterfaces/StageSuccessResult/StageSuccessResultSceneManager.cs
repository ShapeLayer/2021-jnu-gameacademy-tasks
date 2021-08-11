using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSuccessResultSceneManager : MonoBehaviour
{
    void Start()
    {
        if (IngameDataManager.instance.level.nextLevelID == "none")
            Destroy(GameObject.Find("NextStageButton"));
    }
}
