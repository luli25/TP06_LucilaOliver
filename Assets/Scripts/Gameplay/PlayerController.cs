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
        // Check if the player is pressing the up or down keys while on the ladder
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && box.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            // Determine climbing direction
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 climbingSpeed = new Vector2(rb.velocity.x, verticalInput * playerData.climbSpeed);

            // Apply climbing speed and disable gravity
            //rb.velocity = climbingSpeed;
            rb.velocity = Vector2.down * playerData.climbSpeed;
            Debug.Log(rb.velocity);
            rb.gravityScale = 0;

            // Trigger climbing animation
            anim.SetBool("Climbing", true);
            climbing = true;
        }
        else
        {
            // Re-enable gravity when not climbing
            rb.gravityScale = initialGravity;
            climbing = false;
        }

        // If the player is on the ground, disable climbing
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
