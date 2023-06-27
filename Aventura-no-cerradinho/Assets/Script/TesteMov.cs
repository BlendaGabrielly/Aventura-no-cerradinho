using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteMov : MonoBehaviour
{

    private Rigidbody2D corpoPers;
    private Animator anim;
    private SpriteRenderer spritRend;
   // public Camera cam;
   public Camera cam;

    [SerializeField] private float movHorizontal;
    [SerializeField] private float velocidadeMov=8f;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float velobat=2f;
    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool segundoPulo, conta_pulo;
    [SerializeField] private int vidasAtual ;
    int quantidadeCajus = 0;

    private bool estaPulando;


    void Start()
    {
        corpoPers = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spritRend = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType(typeof(Camera))as Camera;

        vidasAtual = 3;

        velocidadeMov = 10;
        forcaPulo = 15;
    }
    void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        Movimento();
        Pulo();
    }
    private void Movimento(){
      corpoPers.velocity = new Vector3(movHorizontal * velocidadeMov, corpoPers.velocity.y);
        if (movHorizontal > 0 ){
            spritRend.flipX = false;
            anim.SetBool("Correndo", true);
        }
        else if(movHorizontal < 0 ){
            spritRend.flipX = true;
            anim.SetBool("Correndo", true);
        }
        else if (movHorizontal == 0)
        {
            anim.SetBool("Correndo", false);
        }
    }
    private void Pulo(){   

        if (Input.GetButtonDown("Jump")){

            if (!estaPulando) {
                corpoPers.AddForce(new Vector2(corpoPers.velocity.x, forcaPulo), ForceMode2D.Impulse);
                estaPulando = true;
            }
            if (segundoPulo)
            {
                corpoPers.AddForce(new Vector2(0f, (forcaPulo/2)), ForceMode2D.Impulse);
                segundoPulo = false;
            }
        }
    }
    void bufferDePulo(){
        if (conta_pulo){
            corpoPers.AddForce(new Vector2(corpoPers.velocity.x, forcaPulo), ForceMode2D.Impulse);
            conta_pulo = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            //Debug.Log("Bati no chão");
            estaPulando = false;
            bufferDePulo();

        }if (collision.gameObject.tag == "Enemy"){
            //Destroy(gameObject);
            GameController.insta.ShowGameOver();
            //Destroy(collision.gameObject);
        }

    }
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.layer == 8){
            segundoPulo = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    { 
         if(collider.gameObject.tag=="Arbusto"){
              velocidadeMov =velobat;
              cam.ShakeIt();
              Invoke("retorno", 2f);
           }      
        // if(collider.gameObject.tag=="Caju"){
         //     velocidadeMov =velocidadeMov*2;
          //    Invoke("retorno", 2f);
          // }

        if(collider.gameObject.tag=="Caju"){
           quantidadeCajus = quantidadeCajus + 1;

            velocidadeMov = velocidadeMov*2;
            Invoke("retorno", 2f); 
            Debug.Log("pegou caju: " + quantidadeCajus); 

            if (quantidadeCajus > 2)
            {
                Debug.Log("pegou caju, entrou no if");
                retorno();
                quantidadeCajus = 0;
            }
            
        }
    }

    void retorno(){
           velocidadeMov=8f;
        }     
}

