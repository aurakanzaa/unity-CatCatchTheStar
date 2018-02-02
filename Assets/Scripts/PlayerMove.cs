using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10;
    private Rigidbody2D rigidBody2D;
    private Animator myAnimator;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    [SerializeField]
    private float jumpForce;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }
    void FixedUpdate()
    {
        isGrounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        float xMove = Input.GetAxis("Horizontal");
        Movement(xMove);

        resetValues();
    }
    private void Movement(float xMove)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            rigidBody2D.AddForce(new Vector2(0, jumpForce));
        }
        rigidBody2D.velocity = new Vector2(xMove * speed, rigidBody2D.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(xMove));
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    private void resetValues()
    {
        jump = false;
    }
    private bool IsGrounded()
    {
        if (rigidBody2D.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
