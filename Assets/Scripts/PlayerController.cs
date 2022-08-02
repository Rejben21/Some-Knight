using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public bool stopMove = false;

    public LayerMask WhatIsGround;
    public Transform groundPoint;
    public bool isGrounded, isBlocking, canJump, isAttacking, canBlock, canAttack, canMove;
    public Rigidbody2D rB;
    public float moveSpeed, jumpForce, blockMoveSpeed;
    public Animator anim;
    private float timeToAttack;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, WhatIsGround);

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            rB.velocity = new Vector2(rB.velocity.x, jumpForce);
        }

        if(canMove)
        {
            rB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rB.velocity.y);
        }

        //swich side
        if(rB.velocity.x > 0)
        {
            this.gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
        }
        else if(rB.velocity.x < 0)
        {
            this.gameObject.transform.localScale = new Vector2(-0.5f, 0.5f);
        }

        //block
        if(Input.GetKey(KeyCode.Mouse1) && canBlock == true)
        {
            isBlocking = true;
            canJump = false;
            canAttack = false;
            canMove = false;
            rB.velocity = new Vector2(blockMoveSpeed * Input.GetAxis("Horizontal"), rB.velocity.y);
        }
        else
        {
            isBlocking = false;
            canJump = true;
            canAttack = true;
            canMove = true;
        }

        //attack
        if(Input.GetKeyDown(KeyCode.Mouse0) && canAttack == true && isGrounded == true)
        {
            anim.Play("PlayerAttack");
            canBlock = false;
        }
        else
        {
            canBlock = true;
        }
        anim.SetFloat("Speed", Mathf.Abs(rB.velocity.x));
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsBlocking", isBlocking);
    }
}
