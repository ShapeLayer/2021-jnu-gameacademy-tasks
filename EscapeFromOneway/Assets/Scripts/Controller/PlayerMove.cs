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

    void Start()
    {
        tr = GetComponent<Transform>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {

        //float x = Input.GetAxis("Horizontal") * speed;
        //float y = Input.GetAxis("Vertical") * speed;

       // bool L = false, U = false, D = false;

       // animator.SetTrigger("Left");
       // animator.SetTrigger("Forward");
        //animator.SetTrigger("Backward");


        if (Input.GetKeyDown("left"))
        {
            //L = Input.GetKeyDown("left");
            animator.SetTrigger("Left");

            tr.position = new Vector2(tr.position.x - 3, tr.position.y);

        }
        if (Input.GetKeyDown("up"))
        {
            // U = Input.GetKeyDown("up");
            animator.SetTrigger("Forward");

            tr.position = new Vector2(tr.position.x, tr.position.y + 3);

        }
        if (Input.GetKeyDown("right"))
        {
            tr.position = new Vector2(tr.position.x + 3, tr.position.y);
        }
        if (Input.GetKeyDown("down"))
        {
             //D = Input.GetKeyDown("down");
            animator.SetTrigger("Backward");
            tr.position = new Vector2(tr.position.x, tr.position.y - 3);

        }

    }

    void animatorChange()
    {

    }



}
