using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string UserName;
    public List<string> UnlockedCharacters;
    public List<string> ClearedStages;
    public InfinityScore InfinityHighest;
    public static bool CheckBinaryStorageIsExisted() { return File.Exists(PathVariables.UserDataBinaryStorage); }
    public static void InitializeBinaryStorage() { if (!CheckBinaryStorageIsExisted()) File.Create(PathVariables.UserDataBinaryStorage); }
    public void AddUnlockedCharacter(string id) { UnlockedCharacters.Add(id); }
    public void RemoveUnlockedCharacter(string id) { UnlockedCharacters.Remove(id); }
    public void AddClearedStage(string id) { ClearedStages.Add(id); }
    public void RemoveClearedStage(string id) { ClearedStages.Remove(id); }
    public void UpdateScore(int score) { InfinityHighest.UpdateScore(score); }
}

[System.Serializable]
public class InfinityScore
{
    public int Score;
    public DateTime AchievedTime;

    public void UpdateScore(int score)
    {
        Score = score;
        AchievedTime = DateTime.Now;
    }
}
