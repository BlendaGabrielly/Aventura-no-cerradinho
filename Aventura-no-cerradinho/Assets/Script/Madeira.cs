using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madeira : MonoBehaviour
{
    public float time;
    private TargetJoint2D target;
    private BoxCollider2D box;
    void Start()
    {
       target = GetComponent<TargetJoint2D>();
       box = GetComponent<BoxCollider2D>(); 
    }
    void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.tag=="Player"){
          Invoke("Falling",time);
      }
   }
   void OnTriggerEnter2D(Collider2D collider){
         if(collider.gameObject.tag=="Lago"){
          Destroy(gameObject);
      }
 }
    
    
    void Falling(){
        target.enabled=false;
        box.isTrigger=true;
    }
}


