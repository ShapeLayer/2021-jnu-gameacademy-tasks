using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string type;
    public LevelConfig config;
    public List<int> path;
    public int length;
    public string nextLevelID;
}

public class LevelConfig
{
}
