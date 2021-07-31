using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public UserData UserData;

    void Start() {}
    void Update() {}


    /* 
        Methods bound with  ContextMenu
    */
    [ContextMenu("Debug Initialize Binary Storage")]
    void DebugInitializeBinaryStorage() { UserData.InitializeBinaryStorage(); }

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
