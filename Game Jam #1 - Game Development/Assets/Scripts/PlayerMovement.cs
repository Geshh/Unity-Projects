using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject parentGameObject;
    public float speed;
    public float jumpForce;
    private float moveInput;
    // Use this for initialization
    private bool isGrounded;
    public Transform feetPos;
    private float checkRadius = 0.3f;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Animator anim;
    public bool m_FacingRight = true;
    private Rigidbody2D rb;

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;
        // Multiply the player's x local scale by -1.
        Vector3 theScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;
        theScale.x *= -1;
        GameObject.FindGameObjectWithTag("Player").transform.localScale = theScale;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = parentGameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput == -1 && m_FacingRight)
        {
            Flip();
        }
        else if (moveInput == 1 && !m_FacingRight)
        {
            Flip();
        }
        if (moveInput != 0)
        {
            anim.SetBool("isWalking", true);
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumpingImproved", true);
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isCrouching", false);
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isJumpingImproved", false);
            isJumping = false;
        }
    }

}
