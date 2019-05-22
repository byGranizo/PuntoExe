using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Moves : MonoBehaviour
{
    private Animator anim;//control the Animator component of GsmrObject
    private Rigidbody2D rb2d;

    [SerializeField] float speedMove;

    [SerializeField] float length;
    float starPosition;
    float counter;

    float currentPosition;
    float lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        starPosition = transform.position.x;
        counter = transform.position.x;
    }
    
    // Update is called once per frame
    void Update()
    {
       
        counter += Time.deltaTime * speedMove;
         
        transform.position = new Vector2((starPosition + Mathf.PingPong(counter, length)), transform.position.y);

        currentPosition = transform.position.x;

        //Debug.Log(transform.position.x);

        if (currentPosition < lastPosition) transform.localScale = new Vector3(-1, 1, 1);
        if (currentPosition > lastPosition) transform.localScale = new Vector3(1, 1, 1);

        lastPosition = transform.position.x;
       
      
    }

    
}
