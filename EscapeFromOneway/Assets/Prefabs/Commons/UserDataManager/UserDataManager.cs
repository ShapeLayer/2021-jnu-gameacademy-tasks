using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class UserDataManager : MonoBehaviour
{
    public static UserDataManager instance = null;
    public UserData UserData;

    public bool CheckBinaryStorageIsExisted()
    {
        if (!Directory.Exists(PathVariables.UserDataBinaryStorageDir)) Directory.CreateDirectory(PathVariables.UserDataBinaryStorageDir);
        return File.Exists(PathVariables.UserDataBinaryStorage);
    }
    public void InitializeBinaryStorage()
    {
        if (!CheckBinaryStorageIsExisted()) File.Create(PathVariables.UserDataBinaryStorage).Close();
    }

    public void SaveUserDataToBinaryStorage()
    {
        InitializeBinaryStorage();
        File.WriteAllText(PathVariables.UserDataBinaryStorage, JsonConvert.SerializeObject(UserData));
    }
    public void LoadUserDataFromBinaryStorage() {
        InitializeBinaryStorage();
        UserData = PresetController.LoadJsonToObject(PathVariables.UserDataBinaryStorage).ToObject<UserData>();
    }

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        InitializeBinaryStorage();
    }

    /* 
        Methods bound with ContextMenu.
    */
    [ContextMenu("Debug Initialize Binary Storage")]
    void DebugInitializeBinaryStorage() { InitializeBinaryStorage(); }

    [ContextMenu("Debug Save User Data to Binary Storage")]
    void DebugSaveUserDataToBinaryStorage() { SaveUserDataToBinaryStorage(); }

    [ContextMenu("Debug Load User Data from Binary Storage")]
    void DebugLoadUserDataFromBinaryStorage() { LoadUserDataFromBinaryStorage(); }

    [ContextMenu("Debug Add Unlocked Characters")]
    void DebugAddUnlockedCharacters() { UserData.AddUnlockedCharacter("Dino"); }

    [ContextMenu("Debug Remove Unlocked Characters")]
    void DebugRemoveUnlockedCharacters() { UserData.RemoveUnlockedCharacter("Dino"); }

    [ContextMenu("Debug Add Cleared Stages")]
    void DebugAddClearedStages() { UserData.AddClearedStage("1"); }

    [ContextMenu("Debug Remove Cleared Stages")]
    void DebugRemoveClearedStages() { UserData.RemoveClearedStage("1"); }

    [ContextMenu("Debug Update Infinity Score")]
    void DebugUpdateInfinityScore() { UserData.UpdateScore(10); }
}
