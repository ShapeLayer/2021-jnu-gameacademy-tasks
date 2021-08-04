using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoadManager : MonoBehaviour
{
    // Data Containers
    public List<string> levelIndex;
    List<string> UnlockedStages;
    List<string> ClearedStages;
    public int[] scenePaginatorIndex = {1, 1}; // Current, Total

    // Prefab Resources
    public GameObject BaseParentPanel;
    public GameObject StagesParentPanel;
    public GameObject BlueButton;
    public GameObject BlueLockButton;
    public GameObject BlueHomeButton;
    public GameObject BlueForwardButton;

    void Start()
    {
        LoadLevelIndex();
        UnlockedStages = UserDataManager.instance.UserData.UnlockedStages;
        ClearedStages = UserDataManager.instance.UserData.ClearedStages;
        InstantiateParents();
        ConstructBaseButtons();
        ConstructStageButtons();
    }

    public void LoadLevelIndex() { levelIndex = PresetController.LoadJsonToArray(PathVariables.LevelIndex).ToObject<List<string>>(); }
    [ContextMenu("DebugLoadLevelIndex")] public void DebugLoadLevelIndex() { LoadLevelIndex(); }
    
    public void RegenParent(string type)
    {
        if (type == "base")
        {
            Destroy(GameObject.Find("Base"));
            InstantiateParent(BaseParentPanel);
        }
        else if (type == "stages")
        {
            Destroy(GameObject.Find("Stages"));
            InstantiateParent(StagesParentPanel);
        }
    }
    [ContextMenu("DebugRegenParent")] public void DebugRegenParent() { RegenParent("base"); }

    void InstantiateParent(GameObject GameObject)
    {
        GameObject newObject = Instantiate(GameObject) as GameObject;
        newObject.transform.SetParent(GameObject.Find("Panel").transform);
        newObject.name = newObject.name.Replace("(Clone)", "");
    }

    [ContextMenu(("DebugInstantiateParents"))]
    void InstantiateParents()
    {
        List<GameObject> Parents = new List<GameObject>();
        Parents.Add(BaseParentPanel);
        Parents.Add(StagesParentPanel);
        foreach (GameObject Parent in Parents)
        {
            InstantiateParent(Parent);
        }
    }

    GameObject InstantiateButton(GameObject GameObject, string ParentObjectName, Vector3 Position, RectAnchors RectAnchors, Vector3 Scale = default(Vector3))
    {
        GameObject newObject = Instantiate(GameObject) as GameObject;
        RectTransform Rect = newObject.GetComponent<RectTransform>();
        newObject.transform.SetParent(GameObject.Find(ParentObjectName).transform);
        Rect.anchorMin = RectAnchors.anchorMin;
        Rect.anchorMax = RectAnchors.anchorMax;
        Rect.pivot = RectAnchors.pivot;
        Rect.anchoredPosition = Position;
        Rect.sizeDelta = new Vector2(StageConstructorConfig.ButtonSize, StageConstructorConfig.ButtonSize);
        if (Scale == default(Vector3)) Scale = new Vector3(1, 1, 1);
        Rect.localScale = Scale;
        return newObject;
    }

    void ConstructBaseButtons() { ConstructBaseButtons(true, true, true); }
    void ConstructBaseButtons(bool home, bool left, bool right)
    {
        if (home) InstantiateButton(
            BlueHomeButton, "Base", new Vector3(
                StageConstructorConfig.ButtonMargin,
                StageConstructorConfig.ButtonMargin * -1,
                0),
            RectVariables.TopLeft
        );
        if (left) InstantiateButton(
            BlueForwardButton, "Base", new Vector3(
                StageConstructorConfig.ButtonMargin + StageConstructorConfig.ButtonSize, 
                StageConstructorConfig.ButtonMargin,
                0),
            RectVariables.BottomLeft, new Vector3(-1, 1, 1)
        );
        if (right) InstantiateButton(
            BlueForwardButton, "Base", new Vector3(
                StageConstructorConfig.ButtonMargin * -1,
                StageConstructorConfig.ButtonMargin, 
                0), 
            RectVariables.BottomRight
        );
    }
    [ContextMenu("ConstructStageButtons")]
    public void ConstructStageButtons()
    {
        scenePaginatorIndex[1] = (int)Math.Ceiling(((float)levelIndex.Count/9));
        for (
            int i = (scenePaginatorIndex[0]-1)*9+1;
            scenePaginatorIndex[0]*9 > levelIndex.Count ? i <= levelIndex.Count : i <= scenePaginatorIndex[0]*9;
            i++
        )
        {
            GameObject newObject = new GameObject();
            if (i % 9 == 1) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                StageConstructorConfig.ButtonMargin,
                (StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize) * -1,
                0),
                RectVariables.TopLeft
            );
            else if (i % 9 == 2) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                0,
                (StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize) * -1,
                0),
                RectVariables.TopCenter
            );
            else if (i % 9 == 3) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                StageConstructorConfig.ButtonMargin * -1,
                (StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize) * -1,
                0),
                RectVariables.TopRight
            );
            else if (i % 9 == 4) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                StageConstructorConfig.ButtonMargin,
                0,
                0),
                RectVariables.MiddleLeft
            );
            else if (i % 9 == 5) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                0,
                0,
                0),
                RectVariables.MiddleCenter
            );
            else if (i % 9 == 6) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                StageConstructorConfig.ButtonMargin * -1,
                0,
                0),
                RectVariables.MiddleRight
            );
            else if (i % 9 == 7) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                StageConstructorConfig.ButtonMargin,
                StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize,
                0),
                RectVariables.BottomLeft
            );
            else if (i % 9 == 8) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                0,
                StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize,
                0),
                RectVariables.BottomCenter
            );
            else if (i % 9 == 0) newObject = InstantiateButton(BlueButton, "Stages", new Vector3(
                StageConstructorConfig.ButtonMargin * -1,
                StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize,
                0),
                RectVariables.BottomRight
            );
            newObject.GetComponent<SpecificStageButtonController>().Text.text = levelIndex[i-1];
        }
    }
    [ContextMenu("ConstructBaseButton")]
    public void DebugConstructBaseButtons() {ConstructBaseButtons();}
}
