using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    Transform tr;
    Animator animator;

    public float speed;
    public Sprite Forward;
    public Sprite Backward;
    public Sprite Left;

    int direction = 1000000;

    void Start()
    {
        tr = GetComponent<Transform>();

        animator = GetComponent<Animator>();


    }

    void Update()
    {

        // animator.SetTrigger("Left");
        // animator.SetTrigger("Forward");
        //animator.SetTrigger("Backward");

        if (Input.GetKeyDown("up")) //윗방향키 입력
        {
            if(direction % 4 == 0) //정면 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y + 3);
            }
            if (direction % 4 == 1) //오른쪽 주시
            {
                transform.localScale = new Vector3(-1, 1, 1);
                tr.position = new Vector2(tr.position.x + 3, tr.position.y);
            }
            if (direction % 4 == 2) //아래 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y - 3);
            }
            if (direction % 4 == 3) //왼쪽 주시
            {
                transform.localScale = new Vector3(1, 1, 1);
                tr.position = new Vector2(tr.position.x - 3, tr.position.y);
            }
            //yield return new WaitForSeconds(0.3f);
            //animator.SetInteger("Forward", 5);

            // animator.SetTrigger("Forward");
        }


        if (Input.GetKeyDown("right"))
        {
            direction += 1;

            if (direction % 4 == 0) //정면 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y + 3);
            }
            if (direction % 4 == 1) //오른쪽 주시
            {
                transform.localScale = new Vector3(-1, 1, 1);
                tr.position = new Vector2(tr.position.x + 3, tr.position.y);
            }
            if (direction % 4 == 2) //아래 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y - 3);
            }
            if (direction % 4 == 3) //왼쪽 주시
            {
                transform.localScale = new Vector3(1, 1, 1);
                tr.position = new Vector2(tr.position.x - 3, tr.position.y);
            }
        }


        if (Input.GetKeyDown("left"))
        {

            direction -= 1;
            if (direction % 4 == 0) //정면 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y + 3);
            }
            if (direction % 4 == 1) //오른쪽 주시
            {
                transform.localScale = new Vector3(-1, 1, 1);
                tr.position = new Vector2(tr.position.x + 3, tr.position.y);
            }
            if (direction % 4 == 2) //아래 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y - 3);
            }
            if (direction % 4 == 3) //왼쪽 주시
            {
                transform.localScale = new Vector3( 1, 1, 1);
                tr.position = new Vector2(tr.position.x - 3, tr.position.y);
            }
           // animator.SetTrigger("Left");

        }

        animator.SetInteger("direction", direction % 4);
    }

    void animatorChange()
    {

    }

    /*
    void keyPress()
    {
          if (direction % 4 == 0) //정면 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y + 3);
            }
            if (direction % 4 == 1) //오른쪽 주시
            {
                tr.position = new Vector2(tr.position.x + 3, tr.position.y);
            }
            if (direction % 4 == 2) //아래 주시
            {
                tr.position = new Vector2(tr.position.x, tr.position.y - 3);
            }
            if (direction % 4 == 3) //왼쪽 주시
            {
                tr.position = new Vector2(tr.position.x - 3, tr.position.y);
            }
    }
    */
}
