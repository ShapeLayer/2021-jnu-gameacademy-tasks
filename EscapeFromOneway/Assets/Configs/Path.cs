using System.IO;
using UnityEngine;

class PathVariables
{
    public static string Presets;
    public static string Prefabs;
    public static string Levels;
    
    public static string LevelIndex;
    public static string LevelDir;

    public static string UserDataBinaryStorage;

    static PathVariables()
    {
        Presets = Path.Combine(Application.dataPath, "Presets");
        Prefabs = Path.Combine(Application.dataPath, "Prefabs");
        LevelIndex = Path.Combine(PathVariables.Presets, "Levels.json");
        LevelDir = Path.Combine(PathVariables.Presets, "Levels");
        UserDataBinaryStorage = Path.Combine(Application.dataPath, "BinaryStorage", "UserData.dat");
    }
}
