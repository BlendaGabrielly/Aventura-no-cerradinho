using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public float velocidade = 8f;
    public float velobat=3f;
    public float forcaPulo = 8f;

    public bool estaPulando, segundoPulo;
    private Camera camera;

    private Rigidbody2D rig;
    private Animator anim;
  
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        camera=FindObjectOfType(typeof(Camera))as Camera;
    }

    // Update is called once per frame
    void Update()
    {
       //Move();
       //Jump(); 
    }

   

     void OnTriggerEnter2D(Collider2D collider){
           if(collider.gameObject.tag=="Arbusto"){
              velocidade=velobat;
              camera.ShakeIt();
              Invoke("retorno",2f);
           }
        }
        void retorno(){
           velocidade=8f;
           
        }

}
