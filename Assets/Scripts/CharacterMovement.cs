using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private float jump = 20f;
    private BoxCollider2D collider;
    private Animator anim;
    private float moveHorizontal;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        anim = GetComponent<Animator>();
        anim.SetFloat("Horizontal",1);
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        if (rb.velocity.x != 0.0f){
            anim.SetBool("isMoving", true);
        }else if(rb.velocity.x == 0.0f){
            anim.SetBool("isMoving", false);
        }

        if(moveHorizontal > 0){
            anim.SetFloat("Horizontal", 1);
        }else if(moveHorizontal < 0){
            anim.SetFloat("Horizontal", -1);
        }
        

        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)){
            if(IsGrounded()){
                anim.SetBool("isJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }else{
                anim.SetBool("isJumping", false);
            }
        }

        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f);
        }

        if(IsGrounded()){
            anim.SetBool("isJumping", false);
        }else if(IsGrounded() == false){
            anim.SetBool("isJumping", true);

        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.7f, groundLayer);
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector2 (moveHorizontal*speed, rb.velocity.y);
    }
}
