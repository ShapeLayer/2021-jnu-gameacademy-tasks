using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBridgeController : MonoBehaviour
{
    public GameObject TileObject;
    SpriteRenderer SpriteRenderer;
    int isBlockDestroying = 0;
    string type = "normal";

    public void Init(GameObject GameObject)
    {
        TileObject = Instantiate(GameObject) as GameObject;
        TileObject.transform.SetParent(this.gameObject.transform);
        TileObject.transform.localPosition = new Vector2(0, 0);
    }

    void Start()
    {
        this.SpriteRenderer = TileObject.GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        DisappearHandler();
    }
    public void ChangeConstantState(string Type)
    {
        type = Type;
    }
    public string TriggerDisappear()
    {
        if (type == "normal") isBlockDestroying = 1;
        return type;
    }
    void DisappearHandler()
    {
        if (this.SpriteRenderer.color.a <= 0)
        {
            Destroy(this.gameObject);
        }
        this.SpriteRenderer.color = new Color(1f, 1f, 1f, this.SpriteRenderer.color.a - MapConstructorConfig.TileTransparentParam * Time.deltaTime * isBlockDestroying);
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - MapConstructorConfig.TileMoveDownParam * Time.deltaTime * isBlockDestroying);
    }
}
