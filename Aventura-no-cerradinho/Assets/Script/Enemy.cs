using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public float Speed;
    private Transform Target;

    private BoxCollider2D Onca, madeiraCollider;
   // public float Stop;

    
    void Start()
    {
       /* Onca = GetComponent<BoxCollider2D>();
        madeiraCollider = GameObject.Find("madeira").GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(madeiraCollider, Onca, true);
        */

        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Onca = GetComponent<BoxCollider2D>();
        madeiraCollider = GameObject.FindGameObjectWithTag("madeira").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision( Onca, madeiraCollider, true);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position=Vector3.MoveTowards(transform.position,Target.position,Speed*Time.deltaTime);
    }
     void OnCollisionEnter2D(Collision2D collision){


        if (collision.gameObject.tag == "Player") {
            GameController.insta.ShowGameOver();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
     }
     
}


