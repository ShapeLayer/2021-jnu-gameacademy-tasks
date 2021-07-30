using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.SpriteRenderer;

public class PlayerMove : MonoBehaviour
{

    Transform tr;

    // SpriteRenderer sc = Transform.GetComponent<SpriteRenderer>();

    //SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
    //Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Player/charcter_idle");
    // SpriteRenderer spr = GetComponent<SpriteRenderer>();
    //public GameObject player_left;

    public float speed;

    void Start()
    {
        tr = GetComponent<Transform>();


    }

    void Update()
    {

        //float x = Input.GetAxis("Horizontal") * speed;
        //float y = Input.GetAxis("Vertical") * speed;

        if (Input.GetKeyDown("left"))
        {
            //for (; tr.position.x == tr.position.x + 3; tr.position.x =+ speed)
            tr.position = new Vector2(tr.position.x - 3, tr.position.y);



            //tr.position = new Vector2(tr.position.x - 3, tr.position.y);

            //sc = (Sprite)Resources.Load("idle_21", typeof(Sprite));
            //spriteR.sprite = sprites[21];
            //spr.sprite = Resources.Load<Sprite>("Player/character_idle/idle_21");
            //player_left.GetComponent<SpriteRenderer>().sprite = Resources.Load("idle_21", typeof(Sprite)) as Sprite;

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
