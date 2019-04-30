using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMoves : MonoBehaviour
{
    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;
    public float speed;
    private float time = 10.5f;

    int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();//set component animator
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Flip();
        }

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
