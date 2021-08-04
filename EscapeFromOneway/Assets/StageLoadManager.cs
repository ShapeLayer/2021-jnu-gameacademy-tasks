using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoadManager : MonoBehaviour
{
    // Data Containers
    public List<string> levelIndex;
    List<string> UnlockedStages;
    List<string> ClearedStages;

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
    
    void ConstructBaseButton() { ConstructBaseButton(true, true, true); }
    void ConstructBaseButton(bool home, bool left, bool right)
    {
        GameObject HomeButton = Instantiate(BlueHomeButton) as GameObject;
        
    }
    public void ConstructStageButton()
    {
        foreach (var level in levelIndex)
        {
            if (ClearedStages.Contains(level))
            {}
            else if (UnlockedStages.Contains(level))
            {}
            else
            {}
        }
    }
}
