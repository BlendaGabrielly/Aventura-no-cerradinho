using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madeira : MonoBehaviour
{
    public float time;
    private TargetJoint2D target;
    private BoxCollider2D box;

     public Vector3 initialPosition;
    // public Quaternion initialRotation;
    // public Vector3 initialScale;

    void Start()
    {
       initialPosition = transform.position;
       target = GetComponent<TargetJoint2D>();
       box = GetComponent<BoxCollider2D>(); 
    }
    void Update(){
        Vector3 boxColliderPosition = box.bounds.center;
        Debug.Log("Posição do BoxCollider: " + boxColliderPosition);
        Debug.Log("Posição inicial do BoxCollider: " + initialPosition);
    }
    void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.tag=="Player"){
          Invoke("Falling",time);
          Invoke("Rest",8f);
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


