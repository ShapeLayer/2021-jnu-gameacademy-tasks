using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConstructor : MonoBehaviour
{
    public GameObject MapTilePrefab;
    public GameObject[] MapTilePrefabs;
    public int[] ConstructOffset = {3, 3};

    // GeneratePath
    List<int> pathGen;

    void Start()
    {
        IngameDataManager.instance.DebugSetLevelID();
        IngameDataManager.instance.LoadLevel();
        ConstructMap();
    }

    void Update() {}

    public List<int> GeneratePath(int length) { return GeneratePath(length, MapConstructorConfig.CanGenBackwardPath); }
    public List<int> GeneratePath(int length, bool CanGenBackwardPath)
    {
        pathGen = new List<int>();
        pathGen.Add(0);
        for (int i = 1; i < length; i++)
        {
            int val;
            do
            {
                if (CanGenBackwardPath) val = Random.Range(0, 4);
                else val = Random.Range(0, 3);
            } while (
                (val == 0 && pathGen[i-1] == 3) ||
                (val == 1 && pathGen[i-1] == 2) ||
                (val == 2 && pathGen[i-1] == 1) ||
                (val == 3 && pathGen[i-1] == 0)
            );
            pathGen.Add(val);
        }
        return pathGen;
    }
    [ContextMenu("Debug Generate Path")]
    public void DebugGeneratePath() 
    {
        foreach (var p in GeneratePath(10))
        {
            print(p);
        }
    }
    
    [ContextMenu("Construct Map")]
    public void ConstructMap()
    {
        int[] ConstructPointer = {0, 0};
        int tileCount = 0;
        foreach(int tile in IngameDataManager.instance.level.path)
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
