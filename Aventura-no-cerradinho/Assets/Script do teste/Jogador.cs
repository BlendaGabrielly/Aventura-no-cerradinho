using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public float Speed = 8f;
    public float velobat=3f;
    
    public float JumpForce;
    private Camera cam;

    public Rigidbody2D rig;
    private Animator anim;
    //float diretion;
  
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        cam=FindObjectOfType(typeof(Camera))as Camera;
    }

    
    void Update()
    {
       Move();
       Jump();
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position+=movement*Time.deltaTime*Speed;

        if(Input.GetAxis("Horizontal")>0f){
          anim.SetBool("Correndo",true);
          transform.eulerAngles=new Vector3(0f,0f,0f);
        }
        if(Input.GetAxis("Horizontal")<0f){
          anim.SetBool("Correndo",true);
          transform.eulerAngles=new Vector3(0f,180f,0f);
        }
        if(Input.GetAxis("Horizontal")== 0f){
          anim.SetBool("Correndo",false);
        }

    }
    void Jump(){
      if(Input.GetKeyDown(KeyCode.Space)){
          rig.AddForce(Vector2.up*JumpForce,ForceMode2D.Impulse);
        }
    }


     void OnTriggerEnter2D(Collider2D collider){
           if(collider.gameObject.tag=="Arbusto"){
              Speed =velobat;
              cam.ShakeIt();
              Invoke("retorno", 2f);
           }
        }
        void retorno(){
           Debug.Log("Hello World");
           Speed=8f;
           
        }

}
