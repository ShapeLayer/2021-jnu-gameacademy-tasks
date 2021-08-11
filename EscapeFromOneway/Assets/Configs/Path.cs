using System.IO;
using UnityEngine;

class PathVariables
{
    public static string Resources;
    public static string Presets;
    public static string Prefabs;
    
    public static string LevelIndex;
    public static string LevelDir;

    public static string UserDataBinaryStorageDir;
    public static string UserDataBinaryStorage;

    static PathVariables()
    {
        Resources = Path.Combine(Application.dataPath, "Resources");
        Presets = Path.Combine(Resources, "Presets");
        Prefabs = Path.Combine(Application.dataPath, "Prefabs");
        LevelIndex = Path.Combine(PathVariables.Presets, "Levels.json");
        LevelDir = Path.Combine(PathVariables.Presets, "Levels");
        UserDataBinaryStorageDir = Path.Combine(Resources, "BinaryStorage");
        UserDataBinaryStorage = Path.Combine(UserDataBinaryStorageDir, "UserData.dat");
    }
}

class ResourceVariables
{
    public static string Presets = "Presets";
    
    public static string LevelIndex = "Presets/Levels";
    public static string LevelDir = "Presets/Levels";

    public static string BinaryStorage = "BinaryStorage";
    public static string UserData = "BinaryStorage/UserData";
}
