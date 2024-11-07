using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GroundDetector groundDetector;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private bool isJumping;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetKey(KeyCode.D) ? 1 : (Input.GetKey(KeyCode.A) ? -1 : 0);
        rb.velocity = new Vector2(moveInput * playerData.speed, rb.velocity.y);
        anim.SetBool("isRunning", moveInput != 0);

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();

        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        if(groundDetector.isGrounded)
        {
            isJumping = false;

            if(Input.GetKey(KeyCode.Space))
            {
                isJumping = true;
                groundDetector.isGrounded = false;
                anim.SetTrigger("OnJump");
                rb.AddForce(Vector2.up * playerData.jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
