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
        //anim = GetComponent<Animator>();
    }

    void Start()
    {   
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      /*  if (col.tag == "Player")
        {
            
            anim.SetTrigger("do_attack");
            anim.ResetTrigger("finish_attack");
            //Debug.Log("Muñecajo");
        }*/
        
        
    }
    /*void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("Salgoooooo");
            anim.SetTrigger("finish_attack");
            anim.ResetTrigger("do_attack");
        }
       
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
