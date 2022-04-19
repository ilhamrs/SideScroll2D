using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    [SerializeField] private int speed;
    private Animator playerAnim;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //animasi jalan
            playerAnim.SetBool("isWalk", true);
            rbPlayer.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rbPlayer.velocity.y);
            //flip player
            if(Input.GetAxis("Horizontal") > 0.01f)
            {
                transform.localScale = Vector3.one;
            }
            else if (Input.GetAxis("Horizontal") < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            playerAnim.SetBool("isWalk", false);
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
        playerAnim.SetBool("isGround", isGround);
    }

    private void Jump()
    {
        rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, speed);
        playerAnim.SetTrigger("jump");
        isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }
}
