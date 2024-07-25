using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 5;
    public int upSpeed = 3;
    public float jumpForce;

    Rigidbody2D playerRb;
    Animator anim;

    bool isJump = false;
    bool isLadder = false;

    //bool isStart = false;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌우이동
        float Xinput = Input.GetAxisRaw("Horizontal");
        playerRb.AddForce(Vector2.right * Xinput, ForceMode2D.Impulse);

        if(playerRb.velocity.x > speed)
        {
            playerRb.velocity = new Vector2(speed, playerRb.velocity.y);
        } else if(playerRb.velocity.x < -speed)
        {
            playerRb.velocity = new Vector2(-speed, playerRb.velocity.y);
        }

        if (Xinput != 0)
        {
            sr.flipX = Input.GetAxisRaw("Horizontal") == 1;
            anim.SetBool("isWalk", true);
        }


        // jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isJump)
            {
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJump = true;
            }
        }


        // 미끄러짐 방지
        if (Input.GetButtonUp("Horizontal"))
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
            anim.SetBool("isWalk", false);
        }

        
    }


    private void FixedUpdate()
    {
        if (isLadder)
        {
            // 위아래 키보드
            float ver = Input.GetAxisRaw("Vertical");
            playerRb.velocity = new Vector2(playerRb.velocity.x, ver * upSpeed);

            playerRb.gravityScale = 0;
        }
        else
        {
            playerRb.gravityScale = 1;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            isJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            isJump = false;
        }
    }
}
