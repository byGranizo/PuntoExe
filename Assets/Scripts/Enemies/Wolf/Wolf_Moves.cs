using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Moves : MonoBehaviour
{
    Collider2D collider;
    bool enter;
    GameObject player;

    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;

    [SerializeField] float speedMove;

    [SerializeField] float length;
    float starPosition;
    float counter;

    float currentPosition;
    float lastPosition;

    [SerializeField] int damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Knight");
        enter = false;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        starPosition = transform.position.x;
        counter = transform.position.x;
        anim.SetTrigger("Idle2Walk");
    }
    
    // Update is called once per frame
    void Update()
    {
       
        counter += Time.deltaTime * speedMove;
         
        transform.position = new Vector2((starPosition + Mathf.PingPong(counter, length)), transform.position.y);

        currentPosition = transform.position.x;

        if (currentPosition < lastPosition) transform.localScale = new Vector3(-1, 1, 1);
        if (currentPosition > lastPosition) transform.localScale = new Vector3(1, 1, 1);

        lastPosition = transform.position.x;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player")
        {
            anim.SetTrigger("Walk2Attack");
            collider = col;
            getHit(collider);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           anim.SetTrigger("Attack2Walk");
        }
        enter = false;
    }

    void OnTriggerStay(Collider other)
    {

        enter = false;
    }

    public void getHit(Collider2D col)
    {
        
        enter = true;
        if(col != null && enter)
        {
            if(col.tag == "Player")
            {
                Debug.Log("Muerdo");

                KnightMovement km;
                km = player.GetComponent<KnightMovement>();

                km.reciveAttack();
            }
        }
       
    }
    //this method is used to set damage 
    public void reciveAttack()
    {
        damage--;
        if (damage == 0)
        {
            Debug.Log(damage);
            anim.SetTrigger("walk2dead");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

    }

}
