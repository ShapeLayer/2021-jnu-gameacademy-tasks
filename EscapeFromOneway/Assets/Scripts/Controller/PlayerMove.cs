using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.SpriteRenderer;

public class PlayerMove : MonoBehaviour
{

    Transform tr;

    // SpriteRenderer sc = Transform.GetComponent<SpriteRenderer>();

    SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
    Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Player/charcter_idle");


    void Start()
    {
        tr = GetComponent<Transform>();


    }

    void Update()
    {


        if (Input.GetKeyDown("left"))
        {
            tr.position = new Vector2(tr.position.x - 3, tr.position.y);
            //sc = (Sprite)Resources.Load("idle_21", typeof(Sprite));
            spriteR.sprite = sprites[21];
        }
        if (Input.GetKeyDown("up"))
        {
            tr.position = new Vector2(tr.position.x, tr.position.y + 3);
        }
        if (Input.GetKeyDown("right"))
        {
            tr.position = new Vector2(tr.position.x + 3, tr.position.y);
        }
        if (Input.GetKeyDown("down"))
        {
            tr.position = new Vector2(tr.position.x, tr.position.y - 3);
        }



    }
}
