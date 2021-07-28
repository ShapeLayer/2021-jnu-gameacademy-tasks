// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConstructor : MonoBehaviour
{
    public GameObject MapTilePrefab;
    public int ConstructOffset = 100;

    // GeneratePath
    List<int> path;

    // ConstructMap
    List<int> ConstructPointer = {0, 0};


    void Start()
    {
        // ConstructMap()
    }

    void Update() {}

    public List<int> GeneratePath(int length)
    {
        for (int i = 0; i < length; i++)
        {
            path.Add(Random.Next(0, 4));
        }
        return path;
    }
    [ContextMenu("Debug Generate Path")]
    public void DebugGeneratePath() { print(GeneratePath(10)); }
    
    [ContextMenu("Construct Map")]
    public void ConstructMap()
    {
        foreach(int tile in IngameDataManager.instance.level.path)
        {
            if (tile == 0) ConstructPointer[0]++;  // Forward
            else if (tile == 1) ConstructPointer[1]++; // Right
            else if (tile == 2) ConstructPointer[1]--; // Left
            else if (tile == 3) ConstructPointer[0]--; // Backward
            GameObject newObject = Instantiate(MapTilePrefab) as GameObject;
            newObject.GetComponent<Transform>().position = new Vector2(
                ConstructPointer[0] * ConstructOffset[0], ConstructPointer[1] * ConstructOffset[1]
            );
        }
    }
}
