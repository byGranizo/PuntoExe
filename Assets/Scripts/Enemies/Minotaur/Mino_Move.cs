using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino_Move : MonoBehaviour
{
    Collider2D collider;
    bool enter;
    GameObject player;

    [SerializeField] int damage;

    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;
   
    [SerializeField] float speed;
    [SerializeField]float speedMove;
    
    [SerializeField] float length;
    float starPosition;
    float counter;

    float currentPosition;
    float lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Knight");
        enter = false;
             
        starPosition = transform.position.x;
        counter = transform.position.x;
        //direction = 1;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();//set component animator
        anim.SetTrigger("go_walk");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.tag == "Player")
        {
            speedMove = 0f;
            anim.SetTrigger("finish_walk");
           
            anim.SetTrigger("do_attack");
            collider = col;
        }
        if (col.tag == "Wall")
        {
            reciveAttack();
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //speedMove = 0.8f;
            anim.SetTrigger("go_walk");
            anim.SetTrigger("finish_attack");
            
        }
        enter = false;
    }

    void OnTriggerStay(Collider other)
    {

        enter = false;
    }

    void Update()
    {
        counter += Time.deltaTime * speedMove;
        transform.position = new Vector2(starPosition + Mathf.PingPong(counter, length), transform.position.y);

        currentPosition = transform.position.x;
       
        if (currentPosition < lastPosition) transform.localScale = new Vector3(-1, 1, 1);
        if (currentPosition > lastPosition) transform.localScale = new Vector3(1, 1, 1);

        lastPosition = transform.position.x;

    }

    public void hit()
    {
        enter = true;
        if (collider != null && enter)
        {
            if (collider.tag == "Player")
            {
                Debug.Log("Muerdo");

                KnightMovement km;
                km = player.GetComponent<KnightMovement>();

                km.getHit();
            }
        }
    }

    //this method is used to set damage 
    public void reciveAttack()
    {
        damage--;
        if(damage == 0)
        {
            Debug.Log(damage);
            anim.SetTrigger("walk2dead");
            speedMove = 0;
            Destroy(gameObject, 3);
        }
    }

    public void die() {
        Destroy(gameObject);
    }



}


