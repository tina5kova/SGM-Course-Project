using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public  float speed ;
    
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(-speed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
       
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        
         if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
       
    }

}
