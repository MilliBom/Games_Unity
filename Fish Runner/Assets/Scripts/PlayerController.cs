using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public float moveSpeed;
    float jumpForce = 6f;
    private int jumpCounter;
    private int jumpCountMax = 1;

    Rigidbody2D rb;
    Collider2D myCollider, myTopCollider;

    public bool isGrounded, isTopGrounded;
    public LayerMask whatIsGround, whatIsTopGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myTopCollider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        isTopGrounded = Physics2D.IsTouchingLayers(myTopCollider, whatIsTopGround);
        
        if (isGrounded == true)
        {
            jumpCounter = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true || isTopGrounded == true) 
            {
                rb.velocity = Vector2.up * jumpForce;
                rb.gravityScale = 1;
            }
            else
            {
                if (jumpCounter < jumpCountMax)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpCounter++;
                    
                    if (jumpCounter == jumpCountMax)
                    {
                        rb.gravityScale = -1;                        
                    }
                }
            }            
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            SceneManager.LoadScene(2);
        }
    }
}
