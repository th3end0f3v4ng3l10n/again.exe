using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour{

    public float speed;
    public float JumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    Animator anim;

    private int extraJumps;
    public int extraJumpsValue;

    private void Start()
    {
        JumpForce = 10;
        extraJumpsValue = 1;
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } 
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) 
        {
            rb.velocity = Vector2.up*JumpForce;
            extraJumps--;
            anim.SetInteger("func", 5);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up*JumpForce;
            
        }

        
        if(Input.GetAxis("Horizontal")==0){
            anim.SetInteger("func", 1);
        }
        else {
            anim.SetInteger("func", 2);
        } 
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}