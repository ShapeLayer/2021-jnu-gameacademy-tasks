using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConstructor : MonoBehaviour
{
    public GameObject MapTilePrefab;
    public GameObject[] MapTilePrefabs;
    public int[] ConstructOffset = {3, 3};

    // GeneratePath
    List<int> path;

    void Start()
    {
        IngameDataManager.instance.DebugSetLevelID();
        IngameDataManager.instance.LoadLevel();
        ConstructMap();
    }

    void Update() {}

    public List<int> GeneratePath(int length)
    {
        path.Add(0);
        for (int i = 0; i < length-1; i++)
        {
            do
            {
                int val = Random.Range(0, 4);
            } while (
                (val == 0 && path[i-1] == 3) ||
                (val == 1 && path[i-1] == 2) ||
                (val == 2 && path[i-1] == 1) ||
                (val == 3 && path[i-1] == 0)
            );
            path.Add(val);
        }
        return path;
    }
    [ContextMenu("Debug Generate Path")]
    public void DebugGeneratePath() { print(GeneratePath(10)); }
    
    [ContextMenu("Construct Map")]
    public void ConstructMap()
    {
        int[] ConstructPointer = {0, 0};
        int tileCount = 0;
        List<int> path = IngameDataManager.instance.level.path;
        foreach(int tile in path)
        {
            if (tile == 0) ConstructPointer[1]++;  // Forward
            else if (tile == 1) ConstructPointer[0]++; // Right
            else if (tile == 2) ConstructPointer[0]--; // Left
            else if (tile == 3) ConstructPointer[1]--; // Backward
            GameObject newObject = Instantiate(MapTilePrefab) as GameObject;
            newObject.GetComponent<Transform>().position = new Vector2(
                ConstructPointer[0] * ConstructOffset[0], ConstructPointer[1] * ConstructOffset[1]
            );
            newObject.GetComponent<SpriteRenderer>().sortingOrder = tileCount;
            newObject.transform.SetParent(GameObject.Find("MapObjects").transform);
            tileCount--;
        }
    }
}
