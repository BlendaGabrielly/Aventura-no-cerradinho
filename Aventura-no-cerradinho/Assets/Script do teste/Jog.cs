using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jog : MonoBehaviour
{
     private Rigidbody2D rig;
    public float speed;
    public float jumpHeight;
    public float jumpVelocity;
    public float gravity;

    void Start()
    {
       rig=GetComponent<Rigidbody2D>(); 
    }
}
    /*void Update()
    {
        Vector2 direction=Vector2.left*speed;
        if(rig.isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
             jumpVelocity=jumpHeight;
            }
        }
         else{
            jumpVelocity-=gravity;
         }
         direction.y=jumpVelocity;
         rig.Move(direction*Time.deltaTime);
    }
}*/
