using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class UserDataManager : MonoBehaviour
{
    public UserData UserData;

    public bool CheckBinaryStorageIsExisted() { return File.Exists(PathVariables.UserDataBinaryStorage); }
    public void InitializeBinaryStorage() { if (!CheckBinaryStorageIsExisted()) File.Create(PathVariables.UserDataBinaryStorage); }

    public void SaveUserDataToBinaryStorage()
    {
        using (
            BinaryWriter writer = new BinaryWriter(
                File.Open(
                    PathVariables.UserDataBinaryStorage, FileMode.Create
                )
            )
        )
        {
            writer.Write(
                JsonConvert.SerializeObject(UserData)
            );
        }
    }
    public void LoadUserDataFromBinaryStorage() {
        using (
            BinaryReader reader = new BinaryReader(
                File.Open(
                    PathVariables.UserDataBinaryStorage, FileMode.Open
                )
            )
        )
        {
            UserData = JObject.Parse(reader.ReadString()).ToObject<UserData>();
        }
    }

    void Start()
    {
        InitializeBinaryStorage();
    }
    void Update() {}

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
