using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 public float Speed;
    private Transform Target;
   // public float Stop;

    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position=Vector3.MoveTowards(transform.position,Target.position,Speed*Time.deltaTime);
    }
     void OnCollisionEnter2D(Collision2D collision){
         if(collision.gameObject.tag=="Player"){
         GameController.insta.ShowGameOver();
         Destroy(gameObject);
      }
     }
     
}


