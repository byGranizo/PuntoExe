using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_Moves : MonoBehaviour
{
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

        player = GameObject.Find("Knight");

        playerPosX = player.transform.position.x;
        playerPosY = player.transform.position.y;

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        starPosition = transform.position.x;
        counter = transform.position.x;
        //anim.SetTrigger("Idle2Walk");
        
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
            Debug.Log("Delante");
        }
        if (transform.position.x > playerPosX)
        {
            //meter perseguir personaje
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.left* speedMove);
            anim.SetTrigger("Idle2Walk");
            Debug.Log("Atras");
           
        }
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            //speedMove = 0f;
            anim.SetTrigger("Walk2Attack");

        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            anim.SetTrigger("Attack2Walk");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
