using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino_Move : MonoBehaviour
{
    Collider2D collider;
    bool enter;
    GameObject player;

    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;
    //int direction;//use to direction´s enemies
    [SerializeField] float speed;
    [SerializeField]float speedMove;
    
    [SerializeField] float length;
    float starPosition;
    float counter;

    float currentPosition;
    float lastPosition;

    //GameObject ogo;
    //float knightX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Knight");
        enter = false;
        speedMove = 0.8f;       
        starPosition = transform.position.x;
        
        //direction = 1;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();//set component animator
        anim.SetTrigger("go_walk");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            //speedMove = 0f;
            //Debug.Log("Wall" + speed);
            
            //Flip();
        }

        if (col.tag == "Player")
        {
            speedMove = 0f;
            anim.SetTrigger("finish_walk");
           
            //speed = 0.4f;
            anim.SetTrigger("do_attack");
            collider = col;
            GetHit(collider);
            //anim.ResetTrigger("finish_attack");
            //Debug.Log("Muñecajo");
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            speedMove = 0.8f;
            anim.SetTrigger("go_walk");
           
            //Debug.Log("Salgoooooo");
            anim.SetTrigger("finish_attack");
            //anim.ResetTrigger("do_attack");

        }
        enter = false;
    }

    void OnTriggerStay(Collider other)
    {

        enter = false;
    }

    void Update()
    {
        //anim.SetFloat("Velocity", speed);
        //Debug.Log( Mathf.Abs(rb2d.velocity.x));
        counter += Time.deltaTime * speedMove;
        transform.position = new Vector2(starPosition + Mathf.PingPong(counter, length), transform.position.y);

        currentPosition = transform.position.x;
       
        if (currentPosition < lastPosition) transform.localScale = new Vector3(-1, 1, 1);
        if (currentPosition > lastPosition) transform.localScale = new Vector3(1, 1, 1);
        lastPosition = transform.position.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    public void GetHit(Collider2D col)
    {
        //if ((playerPos - miPos) < 1)
        //{
        //Debug.Log("Bueno");
        //}
        enter = true;
        if (col != null && enter)
        {
            if (col.tag == "Player")
            {
                Debug.Log("Muerdo");

                KnightMovement km;
                km = player.GetComponent<KnightMovement>();

                km.reciveAttack();
            }
        }


        /*damage--;

        if (damage == 0)
        {
           // Destroy(GameObject.);
        }
        */
    }

}


