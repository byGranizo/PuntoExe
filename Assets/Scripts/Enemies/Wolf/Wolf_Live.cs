using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Live : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int damage;
    float miPos;
    float playerPos;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Knight");
        miPos = Mathf.Abs(transform.position.x);
        playerPos = player.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetHit();
    }

    public float CurrentPosition()
    {
        return transform.position.x;
    }

    public void GetHit()
    {
       
        
        //if ((playerPos - miPos) < 1)
        //{
            Debug.Log("Bueno");
        //}
        damage--;

        if(damage == 0)
        {
            Destroy(GetComponent<Rigidbody>());
        }
        
    }

}
