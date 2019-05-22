using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMoves : MonoBehaviour
{
    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;
    [SerializeField] float speed;
    //private float time = 10.5f;

    [SerializeField] float speedMove;

    [SerializeField] float length;
    float starPosition;
    float counter;

    float currentPosition;
    float lastPosition;

    int direction;

    // Start is called before the first frame update
    void Start()
    {
        speedMove = 0.8f;
        starPosition = transform.position.x;
        lastPosition = transform.position.x + length;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();//set component animator
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime * speedMove;
        transform.position = new Vector2(Mathf.PingPong(counter, length), transform.position.y);

        currentPosition = transform.position.x;

        if (currentPosition < lastPosition) transform.localScale = new Vector3(-1, 1, 1);
        if (currentPosition > lastPosition) transform.localScale = new Vector3(1, 1, 1);
        lastPosition = transform.position.x;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            speedMove = 0f;
            anim.SetTrigger("finish_walk");

            //speed = 0.4f;
            anim.SetTrigger("do_attack");
            //anim.ResetTrigger("finish_attack");
            //Debug.Log("Muñecajo");
        }

    }

    private void Flip()
    {

        direction *= -1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      /* 
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
        */
    }


}
