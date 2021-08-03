using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    Transform tr;
    Animator animator;

    public float speed;

    int direction = 1000000;

    bool IsPause;

    bool isGround;
    public Transform groundCheck;
    public LayerMask groundlayer;

    void Start()
    {
        tr = GetComponent<Transform>();

        animator = GetComponent<Animator>();

        IsPause = false;

        isGround = true;

        LoadSceneAdditive();

        Time.timeScale = 1;
    }

    void Update()
    {

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

        }

        animator.SetInteger("direction", direction % 4);
        /*
        if (isGround)
        {
            Time.timeScale = 1;
            IsPause = false;
        }
        else
        {
            Time.timeScale = 0;
            IsPause = true;
            SceneManager.LoadScene("StageResultUI");
            isGround = false;
        }
        */


    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    void LoadSceneAdditive()
    {
        SceneManager.LoadScene("StageIngameUI", LoadSceneMode.Additive);
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
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Time.timeScale = 1;
            IsPause = false;
        }
        else
        {
            Time.timeScale = 0;
            IsPause = true;
        }
    }*/
}
