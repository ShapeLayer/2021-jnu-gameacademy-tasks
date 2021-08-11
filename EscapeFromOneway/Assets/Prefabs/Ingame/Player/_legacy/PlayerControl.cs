using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    Transform tr;
    Animator animator;

    public float speed;

    public bool IsPause;
    int compareDirection = 1000000;


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

        GameManager.instance.direction = 1000000;
        compareDirection = 1000000;

    }

    void Update()
    {
        if(GameManager.instance.direction != compareDirection)
        {
            keyPress();
        }

        if (Input.GetKeyDown("up")) //������Ű �Է�
        {
            keyPress();
        }

        else if (Input.GetKeyDown("right"))
        {
            GameManager.instance.direction += 1;
            keyPress();
        }

        else if (Input.GetKeyDown("left"))
        {
            GameManager.instance.direction -= 1;
            keyPress();
        }

        animator.SetInteger("direction", GameManager.instance.direction % 4);
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
            GameManager.instance.GameResult = "Fail";
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

    void keyPress()
    {
        if (GameManager.instance.direction % 4 == 0) //���� �ֽ�
        {
            tr.position = new Vector2(tr.position.x, tr.position.y + 3);
        }
        if (GameManager.instance.direction % 4 == 1) //������ �ֽ�
        {
            transform.localScale = new Vector3(-1, 1, 1);
            tr.position = new Vector2(tr.position.x + 3, tr.position.y);
        }
        if (GameManager.instance.direction % 4 == 2) //�Ʒ� �ֽ�
        {
            tr.position = new Vector2(tr.position.x, tr.position.y - 3);
        }
        if (GameManager.instance.direction % 4 == 3) //���� �ֽ�
        {
            transform.localScale = new Vector3(1, 1, 1);
            tr.position = new Vector2(tr.position.x - 3, tr.position.y);
        }
        compareDirection = GameManager.instance.direction;
    }

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
