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

    Rigidbody2D rb2d;
    Animator anim;
    Collider2D bodyCol;


    bool isLookingRight;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bodyCol = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        move();
        jump();
        checkIfFlip();
        updateVerticalAnimation();
    }

    private void move() {
        rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, rb2d.velocity.y);
    }

    private void jump() {
        if (Input.GetButtonDown("Jump")) {
            rb2d.AddForce(new Vector2(0, jumpForce));
        }

        if (rb2d.velocity.y < Mathf.Epsilon) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb2d.velocity.y > Mathf.Epsilon && !Input.GetButton("Jump")) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void updateVerticalAnimation() {
        if (!bodyCol.IsTouchingLayers(LayerMask.GetMask("Terrain"))) {
            anim.SetBool("Run", false);
            anim.SetBool("Ground", false);
            if (rb2d.velocity.y < 0) {
                anim.SetBool("Jump", false);
            } else if (rb2d.velocity.y > 0) {
                anim.SetBool("Jump", true);
            }
        } else {
            anim.SetBool("Ground", true);
            anim.SetBool("Run", Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon);
        }
    }

    private void checkIfFlip() {
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > Mathf.Epsilon) {
            transform.localScale = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x), 1f);
        }
    }
}
