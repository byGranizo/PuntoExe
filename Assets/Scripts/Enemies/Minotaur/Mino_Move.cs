using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino_Move : MonoBehaviour
{
    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;
    int direction;//use to direction´s enemies
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();//set component animator
        speed = Mathf.Abs(rb2d.velocity.x);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Flip();
        }

        if (col.tag == "Player")
        {
            speed = 0;
            anim.SetTrigger("do_attack");
            anim.ResetTrigger("finish_attack");
            //Debug.Log("Muñecajo");
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("Salgoooooo");
            anim.SetTrigger("finish_attack");
            anim.ResetTrigger("do_attack");
        }

    }

    void Update()
    {
        anim.SetFloat("Velocity", speed);
        //Debug.Log( Mathf.Abs(rb2d.velocity.x));
    }

    private void Flip()
    {

        direction *= -1;

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (direction == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(speed, 0, 0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true; //gira el sprite
            transform.Translate(-speed, 0, 0);
        }

    }
}

    
