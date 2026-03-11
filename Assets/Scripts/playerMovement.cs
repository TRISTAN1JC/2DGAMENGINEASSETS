using System;
using System.Collections;
using Unity.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.8f;
    public Vector2 groundCheckOffset = new Vector2(0f, -0.5f);
    public LayerMask groundLayer;
    public Vector2 dashDir;

    private Rigidbody2D rb;
    private float horizInput;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isFacingRight;
    
    //dash parameters
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    /*private*/ void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.A) && isFacingRight == true)
        {
        isFacingRight = false;
        }
    
        if(Input.GetKeyDown(KeyCode.D) && isFacingRight == false)
        {
        isFacingRight = true;
        //print("Directional change");
        }*/

        if (isDashing)
        {
        return;
        }
  
        horizInput = Input.GetAxisRaw("Horizontal");

        Vector2 rayOrigin = groundCheck != null ? (Vector2)groundCheck.position : (Vector2)transform.position + groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.jumpSFX);
        }

        //Attempt at directional movement
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
           float y = Input.GetAxisRaw("Vertical");
            Vector2 dashDir = new Vector2(horizInput, y);
            
            if (dashDir == Vector2.zero)
            dashDir = new Vector2(transform.localScale.x,0);

         // if(isFacingRight != true)
         //rb.linearVelocityX = dashingPower * transform.localScale.x;

            StartCoroutine(Dash(dashDir));
        }


        if (spriteRenderer != null)
        {
            if (horizInput > 0.1f) spriteRenderer.flipX = false;
            else if (horizInput < -0.1f) spriteRenderer.flipX = true;
        }

        // Update animator parameters
        if (animator != null)
        {
            animator.SetFloat("moveInput", Mathf.Abs(horizInput));
            animator.SetBool("isGrounded", isGrounded);
        }
        
    }

    void FixedUpdate()
    {
     if (isDashing)
    {
        return;
    }

        rb.linearVelocity = new Vector2(horizInput * speed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position + (Vector3)groundCheckOffset, transform.position + (Vector3)groundCheckOffset + Vector3.down * groundCheckDistance);
        }
    }

    //Dash Mechanic :D
    private IEnumerator Dash(Vector2 dashDir)
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2 (transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds (dashingCooldown);
        canDash = true;
    }
}