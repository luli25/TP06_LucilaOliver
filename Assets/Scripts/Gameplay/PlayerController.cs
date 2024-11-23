using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GroundDetector groundDetector;

    [SerializeField]
    private Slider playerHealthBar;

    [SerializeField]
    private HealthBarConfig healthBarConfig;

    private BoxCollider2D box;

    private EnemyDamage enemy;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private bool isJumping;
    private bool isCrouching;

    private float initialGravity;
    private bool climbing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = GetComponent<EnemyDamage>();
        box = GetComponent<BoxCollider2D>();
        

        playerData.currentHealth = playerData.maxHealth;
        initialGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Crouch();
    }

    private void FixedUpdate()
    {
        Climb();
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

            if(Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                groundDetector.isGrounded = false;
                anim.SetTrigger("OnJump");
                rb.AddForce(Vector2.up * playerData.jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void Crouch()
    {
        isCrouching = false;
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            anim.SetBool("isCrouching", true);

        } else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            anim.SetBool("isCrouching", false);
        }
    }

    private void Climb()
    {
        float verticalInput = 0;
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }

        if (box.IsTouchingLayers(LayerMask.GetMask("Ladder")) && verticalInput != 0)
        {
            Vector2 climbingSpeed = new Vector2(rb.velocity.x, verticalInput * playerData.climbSpeed);

            rb.isKinematic = true;
            rb.velocity = climbingSpeed;
            rb.gravityScale = 0;

            anim.SetBool("Climbing", true);
            climbing = true;

            if (verticalInput == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
        else
        {
            rb.gravityScale = initialGravity;
            rb.isKinematic = false;
            anim.SetBool("Climbing", false);
            climbing = false;
        }

        if (groundDetector.isGrounded)
        {
            climbing = false;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        playerData.currentHealth -= damageAmount;
        playerHealthBar.value = playerData.currentHealth;

        healthBarConfig.SetHealth(playerData.currentHealth);

        if(playerData.currentHealth <= 0)
        {
            Debug.Log("player dead!");
        }
        
    }
}
