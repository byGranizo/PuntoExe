using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour {

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpForce = 400;
    [Range(1f, 6f)]
    [SerializeField] float fallMultiplier = 2.5f;
    [Range(1f, 6f)]
    [SerializeField] float lowJumpMultiplier = 2f;
    [Range(2f, 10f)]
    [SerializeField] float hitSpeed = 4f;
    [Range(5f, 15f)]
    [SerializeField] float hitSpeedGuarded = 8f;

    Rigidbody2D rb2d;
    Animator anim;
    Collider2D bodyCol;         //Colide with other entities
    Collider2D feetCol;         //Colide with terrain

    bool inGround;
    bool isGuarding;
    bool isAttacking;
    bool isAlive = true;
    bool hitted = false;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bodyCol = GetComponent<Collider2D>();
        feetCol = gameObject.transform.Find("Feet").GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start() {
    }
    // Update is called once per frame
    void Update() {
        controls();
        checkIfHitted();
        verticalMove();
        updateAnimation();
    }

//Loop
    private void controls() {
        if (isAlive) {
            horizontalMove();

            jump();

            guard();

            attack();
        }
    }

    private void horizontalMove() {
        if (!isGuarding && !hitted) {
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, rb2d.velocity.y);

            checkIfFlip();
        }
    }

    private void jump() {
        if (Input.GetButtonDown("Jump") && inGround && !hitted) {
            rb2d.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void guard() {
        if (Input.GetAxisRaw("Vertical") < 0 && inGround) {
            //Stop movement when guard
            if (Input.GetButtonDown("Vertical")) {
                rb2d.velocity = new Vector2(0, 0);
            }
            isGuarding = true;
            anim.SetBool("Guard", true);
        } else {
            isGuarding = false;
            anim.SetBool("Guard", false);
        }
    }

    private void attack() {
        if (!isAttacking) {
            if (Input.GetButtonDown("Fire1")) {
                isAttacking = true;
                anim.SetTrigger("Attack A");
            } else if (Input.GetButtonDown("Fire2")) {
                isAttacking = true;
                anim.SetTrigger("Attack B");
            } else if (Input.GetButtonDown("Fire3")) {
                isAttacking = true;
                anim.SetTrigger("Attack C");
            }
        }
    }

    //Modify the gravity to set the common videogame jump and air movement
    private void verticalMove() {
        if (rb2d.velocity.y < Mathf.Epsilon) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb2d.velocity.y > Mathf.Epsilon && !Input.GetButton("Jump")) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    //Set animations between run and jump
    private void updateAnimation() {
        checkIfGround();
        if (!inGround) {
            anim.SetBool("Run", false);

            anim.SetBool("Jump", rb2d.velocity.y > 0);

        } else if(!hitted) {
            anim.SetBool("Run", Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon);
        }
    }

    //Checks if character is in the hit knockback
    private void checkIfHitted() {
        if (hitted && Math.Abs(rb2d.velocity.x) == 0) {
            hitted = false;
        }
    }

    //Checks if character is looking to the wrong side
    private void checkIfFlip() {
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > Mathf.Epsilon) {
            transform.localScale = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x), 1f);
        }
    }

    private void checkIfGround() {
        inGround = feetCol.IsTouchingLayers(LayerMask.GetMask("Terrain"));
        anim.SetBool("Ground", inGround);
    }

//Other methods
    public void die() {
        isAlive = false;
        anim.SetTrigger("Die");
    }

    public void getHit() {
        hitted = true;
        if (isGuarding) {
            rb2d.velocity = new Vector2(hitSpeedGuarded * -transform.localScale.x, rb2d.velocity.y);
        } else {
            anim.SetTrigger("Hit");
            rb2d.velocity = new Vector2(hitSpeed * -transform.localScale.x, rb2d.velocity.y);
        }
    }

    //When attack animation reach
    private void setAttackFalse() {
        isAttacking = false;
    }
}
