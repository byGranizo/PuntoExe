using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoAttack : MonoBehaviour
{
    private bool attack;
    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Awake()
    {
       // anim.GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           
            anim.SetBool("Attack", true);
            
            Debug.Log("Muñecajo");
        }
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Salgoooooo");
           
            anim.SetBool("Attack", false);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
