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
    public GameObject BlueButton;
    public GameObject BlueLockButton;
    public GameObject BlueHomeButton;
    public GameObject BlueForwardButton;

    void Start()
    {
        LoadLevelIndex();
        UnlockedStages = UserDataManager.instance.UserData.UnlockedStages;
        ClearedStages = UserDataManager.instance.UserData.ClearedStages;
    }

    public void LoadLevelIndex() { levelIndex = PresetController.LoadJsonToArray(PathVariables.LevelIndex).ToObject<List<string>>(); }
    [ContextMenu("DebugLoadLevelIndex")] public void DebugLoadLevelIndex() { LoadLevelIndex(); }
    
    GameObject InstantiateButton(GameObject GameObject, Vector3 Position, RectAnchors RectAnchors, Vector3 Scale = default(Vector3))
    {
        GameObject newObject = Instantiate(GameObject) as GameObject;
        RectTransform Rect = newObject.GetComponent<RectTransform>();
        newObject.transform.SetParent(GameObject.Find("Base").transform);
        Rect.anchorMin = RectAnchors.anchorMin;
        Rect.anchorMax = RectAnchors.anchorMax;
        Rect.pivot = RectAnchors.pivot;
        Rect.anchoredPosition = Position;
        Rect.sizeDelta = new Vector2(StageConstructorConfig.ButtonSize, StageConstructorConfig.ButtonSize);
        if (Scale == default(Vector3)) Scale = new Vector3(1, 1, 1);
        Rect.localScale = Scale;
        return newObject;
    }

    void ConstructBaseButton() { ConstructBaseButton(true, true, true); }
    void ConstructBaseButton(bool home, bool left, bool right)
    {
        if (home) InstantiateButton(
            BlueHomeButton, new Vector3(
                StageConstructorConfig.ButtonMargin,
                StageConstructorConfig.ButtonMargin * -1,
                0),
            RectVariables.TopLeft
        );
        if (left) InstantiateButton(
            BlueForwardButton, new Vector3(
                StageConstructorConfig.ButtonMargin, 
                StageConstructorConfig.ButtonMargin,
                0),
            RectVariables.BottomLeft
        );
        if (right) InstantiateButton(
            BlueForwardButton, new Vector3(
                (StageConstructorConfig.ButtonMargin + StageConstructorConfig.ButtonSize) * -1,
                StageConstructorConfig.ButtonMargin, 
                0), 
            RectVariables.BottomRight, new Vector3(-1, 1, 1)
        );
    }
    [ContextMenu("ConstructStageButton")]
    public void ConstructStageButton()
    {
        scenePaginatorIndex[1] = (int)Math.Ceiling((double)((levelIndex.Count)/9));
        for (
            int i = (scenePaginatorIndex[0]-1)*9+1;
            scenePaginatorIndex[0]*9 > levelIndex.Count ? i <= levelIndex.Count : i <= scenePaginatorIndex[0]*9;
            i++
        )
        {
            if (i % 9 == 1) InstantiateButton(BlueButton, new Vector3(
                StageConstructorConfig.ButtonMargin,
                (StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize) * -1,
                0),
                RectVariables.TopLeft
            );
            else if (i % 9 == 2) InstantiateButton(BlueButton, new Vector3(
                0,
                (StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize) * -1,
                0),
                RectVariables.TopCenter
            );
            else if (i % 9 == 3) InstantiateButton(BlueButton, new Vector3(
                StageConstructorConfig.ButtonMargin * -1,
                (StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize) * -1,
                0),
                RectVariables.TopRight
            );
            else if (i % 9 == 4) InstantiateButton(BlueButton, new Vector3(
                StageConstructorConfig.ButtonMargin,
                0,
                0),
                RectVariables.MiddleLeft
            );
            else if (i % 9 == 5) InstantiateButton(BlueButton, new Vector3(
                0,
                0,
                0),
                RectVariables.MiddleCenter
            );
            else if (i % 9 == 6) InstantiateButton(BlueButton, new Vector3(
                StageConstructorConfig.ButtonMargin * -1,
                0,
                0),
                RectVariables.MiddleRight
            );
            else if (i % 9 == 7) InstantiateButton(BlueButton, new Vector3(
                StageConstructorConfig.ButtonMargin,
                StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize,
                0),
                RectVariables.BottomLeft
            );
            else if (i % 9 == 8) InstantiateButton(BlueButton, new Vector3(
                0,
                StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize,
                0),
                RectVariables.BottomCenter
            );
            else if (i % 9 == 0) InstantiateButton(BlueButton, new Vector3(
                StageConstructorConfig.ButtonMargin * -1,
                StageConstructorConfig.ButtonMargin * 2 + StageConstructorConfig.ButtonSize,
                0),
                RectVariables.BottomRight
            );
        }
    }
    [ContextMenu("ConstructBaseButton")]
    public void DebugConstructBaseButton() {ConstructBaseButton();}
}
