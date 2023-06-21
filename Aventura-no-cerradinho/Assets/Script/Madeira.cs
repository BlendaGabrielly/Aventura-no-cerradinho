using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madeira : MonoBehaviour
{
    public float time;
    private TargetJoint2D target;
    private BoxCollider2D box;

    public Vector3 initialPosition;
    private Vector3 boxColliderPosition;
   // private float distanciaX =+155;

    void Start()
    { 
        //initialPosition = transform.position;
       initialPosition = new Vector3(transform.position.x +155, transform.position.y, transform.position.z);
       target = GetComponent<TargetJoint2D>();
       box = GetComponent<BoxCollider2D>(); 
    }
    void Update(){
        boxColliderPosition = box.bounds.center;
        //Debug.Log("Posição atual:"+boxColliderPosition);
        
     //  Debug.Log("Posição inicial"+initialPosition);
    }
    void OnCollisionEnter2D(Collision2D collision){
      if(collision.gameObject.tag=="Player"){
          Invoke("Falling",time);
          Invoke("RestoreObject",6f);
      }
    }
void RestoreObject(){
   // initialPosition = new Vector3(transform.position.x + distanciaX, transform.position.y, transform.position.z);
    boxColliderPosition = initialPosition;
    transform.position = boxColliderPosition;
    Debug.Log("entrou");


    target.anchor = initialPosition - target.transform.position;//obter um vetor que aponta da posição atual do personagem em direção à posição inicial da câmera. 
    target.enabled = true;
    box.isTrigger = false;
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


