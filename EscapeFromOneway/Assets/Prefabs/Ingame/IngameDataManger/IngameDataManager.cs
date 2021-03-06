using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameDataManager : MonoBehaviour
{
    /// <summary>
    /// Call <c>IngameDataManager.instance</c> when need to use <c>IngameDataManager</c>.
    /// </summary>
    public static IngameDataManager instance = null;
    
    public string levelID;
    public Level level;
    public Character Character;

    private void Awake()
    {
        // Set IngameDataManager unique.
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetLevelID(string LevelID) { levelID = LevelID; }
    public string GetLevelID() { return levelID; }

    public void SetLevel(Level Level) { level = Level; }
    public void LoadLevel()
    {
        level = AssetLoader.LoadJsonToObject(
            Path.Combine(ResourceVariables.LevelDir, levelID)
        ).ToObject<Level>();
    }
    public void LoadLevel(string LevelID) { levelID = LevelID; LoadLevel(); }

    [ContextMenu("DebugSetLevelID")] public void DebugSetLevelID() { SetLevelID("1"); }
    [ContextMenu("DebugLoadLevel")] public void DebugLoadLevel() { LoadLevel("1"); }
}
