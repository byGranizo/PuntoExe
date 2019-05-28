using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Moves : MonoBehaviour
{
    Collider2D collider;
    bool enter;
    bool moving;
    
    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;

    [SerializeField] [Range(0f, 0.05f)] float speedMove;
   
    float starPosition;
    float counter;

    float currentPosition;
    float lastPosition;
    
    float playerPosX;//player position x
    float playerPosY;//player position y

    float distance;
    GameObject player;//Instantiate the main player 

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        enter = false;
        player = GameObject.Find("Knight");

        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        starPosition = transform.position.x;
        counter = transform.position.x;
      
    }

    void FixedUpdate()
    {
        playerPosX = player.transform.position.x;
        //si el gusano esta por detras del jugado
        if (transform.position.x < playerPosX)
        {        
            transform.localScale = new Vector3(1, 1, 1);           
            transform.Translate(Vector3.right * speedMove);
            anim.SetTrigger("Idle2Walk");
        
        }
        if (transform.position.x > playerPosX)
        {
          
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.left* speedMove);
            if (!moving)
            {
                 anim.SetTrigger("Idle2Walk");
            }
            else
            {
                anim.SetTrigger("Walk2Idle");
            }
                   
        }
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.tag == "Player")
        {
            //speedMove = 0f;
            anim.SetTrigger("Walk2Attack");
            collider = col;
            getHit(collider);
        }

        if (col.tag == "Wall")
        {
            speedMove = 0f;
            anim.SetTrigger("Walk2Idle");
           
        }
        moving = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            anim.SetTrigger("Attack2Walk");
        }
        if(col.tag == "Wall")
        {
            moving = false;
        }       
    }

    void OnTriggerStay(Collider other)
    {
        speedMove = 0f;
        anim.SetTrigger("Walk2Idle");
        enter = false;
        moving = true;
    }

    public void getHit(Collider2D col)
    {       
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
