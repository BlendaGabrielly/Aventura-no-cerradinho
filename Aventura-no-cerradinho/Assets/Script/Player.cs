using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float velocidade = 8f;
    public float velobat=3f;
    public float forcaPulo = 8f;

    public bool estaPulando, segundoPulo;
    private Camera camera;

    private Rigidbody2D rig;
    private Animator anim;
    public Color color;
    public GameObject perso;

   // public int max_life=3;
    //private int currentLife;
  //  public float minspeed=10f;
   // public float maxspeed=30f;
   // private bool invincible=false;
 ///   static int blinkValue ;
   // public float invincibleTime;
    //private UIManager iuManager;


    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        camera=FindObjectOfType(typeof(Camera))as Camera;
       // currentLife=max_life; 
       // velocidade=minspeed;
        //blinkValue=Shader.PropertyToID("_BlinkingValue");
        //iuManager=FindObjectOfType<UIManager>();
   

    }

    // Update is called once per frame
    void Update()
    {
        movimentos();
        pulo();
        
    }


    void movimentos()
    {
       
       
            Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movimento * Time.deltaTime * velocidade;

        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("Andando", true);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }


        

    }

    void pulo()
    {
        if (Input.GetButtonDown("Jump"))
        {


            if (!estaPulando)
            {
                rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
                segundoPulo = true;
            }
            else if(segundoPulo) { 
            
                rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
                segundoPulo = false;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
      

        if (collision.gameObject.layer == 7)
        {
            
            estaPulando = false;
            anim.SetBool("Pulando", false);

        }
         if(collision.gameObject.tag== "Enemy"){
         //GameController.insta.ShowGameOver();
         Destroy(gameObject);
      }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            estaPulando = true;
            anim.SetBool("Pulando", true);

        }

    }

    void OnTriggerEnter2D(Collider2D collider){
        //if(invincible){
           // return;
        //}
        //if(collider.gameObject.tag=="Arbusto"){
             //currentLife--;
            // iuManager.UpdateLives(currentLife);

            // anim.SetTrigger("Andando");
            //velocidade = (float)(velocidade - (velocidade * 0.2));
           // if (currentLife<=0){
              // GameController.insta.ShowGameOver();
              // Destroy(gameObject);
            // }else{
             //  StartCoroutine(Blinking(invincibleTime));
          //}
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


    
        
       
   /* IEnumerator Blinking(float time){
      invincible=true;
      float timer=0;
      float currentBlinking=1f;
      float lastBlink=0;
      float blinkPeriod=0.1f;
      yield return new WaitForSeconds(1f);
      velocidade=minspeed;
      while(timer<time&&invincible){
         Shader.SetGlobalFloat(blinkValue,currentBlinking);
         yield return null;
         timer+=Time.deltaTime;
         lastBlink+=Time.deltaTime;
         if(blinkPeriod<lastBlink){
            lastBlink=0;
            currentBlinking=1f-currentBlinking;
         }
     }
     Shader.SetGlobalFloat(blinkValue,0);
     invincible=false;
    }*/
//}