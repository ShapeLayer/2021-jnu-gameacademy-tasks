using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConstructor : MonoBehaviour
{
    // Assosiates with instantiate tile.
    public GameObject TileBridgePrefab;
    public GameObject BasementTilePrefab; // Todo
    public GameObject DebugTilePrefab;

    // Assosiates with sprite rendering.
    int sortingOrder = 0;

    // Assosiates with limiting construct tile.
    int xStack = 0;
    int yStack = 0;
    int indexer = 0;
    List<int> path;

    // Assosiates with pointing construct tile.
    int[] constructPointer = {0, 0};
    bool isConstructedBasement = false;

    // Assosiates with type of map.
    string mapType;

    void Start()
    {
        IngameDataManager.instance.LoadLevel();
        mapType = IngameDataManager.instance.level.type;
        if (mapType == "determined") path = IngameDataManager.instance.level.path;
    }
    void Update()
    {
        if (mapType == "determined") ConstructPathHandler();
        else if (mapType == "random") ConstructRandomHandler();
    }
    public void ConstructTile(GameObject TilePrefab, Vector2 Position, int SortingOrder, string Type = "normal")
    {
        ConstructTile(TilePrefab, Position, SortingOrder, Type, MapConstructorConfig.DefaultParentGameObjectName);
    }
    public void ConstructTile(GameObject TilePrefab, Vector2 Position, int SortingOrder, string Type, string ParentName)
    {
        GameObject newObject = Instantiate(TileBridgePrefab) as GameObject;
        TileBridgeController tileBridgeController = newObject.GetComponent<TileBridgeController>();
        newObject.GetComponent<RectTransform>().position = Position;
        newObject.transform.SetParent(GameObject.Find(ParentName).transform);
        tileBridgeController.Init(TilePrefab);
        if (Type != "normal") tileBridgeController.ChangeConstantState(Type);
        tileBridgeController.TileObject.GetComponent<SpriteRenderer>().sortingOrder = SortingOrder;
    }

    void ConstructPointerHandler(int tile)
    {
        // Forward
        if (tile == 0)
        {
            constructPointer[1]++;
            sortingOrder--;
        }
        else if (tile == 1) constructPointer[0]++; // Right
        // Backward
        else if (tile == 2) 
        {
            constructPointer[1]--;
            sortingOrder++;
        }
        else if (tile == 3) constructPointer[0]--; // Left
    }
    public void ConstructPathHandler()
    {
        // Construct Start(Base Camp) Tile
        if (!isConstructedBasement)
        {
            isConstructedBasement = true;
            sortingOrder--;
            ConstructTile(BasementTilePrefab, new Vector2(0, 0), sortingOrder, "init");
        }

        int length = path.Count;
        // Processing Path
        while (indexer < length && CheckBreakPoint(path[indexer]))
        {
            int tile = path[indexer];
            UpdateBreakPoint("constructor", tile);
            ConstructPointerHandler(tile);
            ConstructTile(
                DebugTilePrefab,
                new Vector2(constructPointer[0] * GameConstructorConfig.TileSizeOffset, constructPointer[1] * GameConstructorConfig.TileSizeOffset),
                sortingOrder
            );
            indexer++;
        }
        if (indexer == length)
        {
            ConstructPointerHandler(path[indexer-1]);
            ConstructTile(
                BasementTilePrefab, 
                new Vector2(constructPointer[0] * GameConstructorConfig.TileSizeOffset, constructPointer[1] * GameConstructorConfig.TileSizeOffset),
                sortingOrder,
                "finish"
            );
            indexer++;
        }
    }

    public void ConstructRandomHandler()
    {}
    
    bool CheckBreakPoint(int tile)
    {
        // Vertical
        if (tile % 2 == 0) return yStack <= MapConstructorConfig.yStackLimit && yStack >= MapConstructorConfig.yStackLimit * -1;
        // Horizontal
        else return xStack <= MapConstructorConfig.xStackLimit && xStack >= MapConstructorConfig.xStackLimit * -1;
    }
    public void UpdateBreakPoint(string updater, int tile)
    {
        if (updater == "player")
        {
            if (tile == 0) yStack--;
            else if (tile == 1) xStack--;
            else if (tile == 2) yStack++;
            else if (tile == 3) xStack++;
        }
        else if (updater == "constructor")
        {
            if (tile == 0) yStack++;
            else if (tile == 1) xStack++;
            else if (tile == 2) yStack--;
            else if (tile == 3) xStack--;
        }
    }
}
