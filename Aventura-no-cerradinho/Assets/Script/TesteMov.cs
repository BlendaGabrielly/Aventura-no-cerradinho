using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteMov : MonoBehaviour
{

    private Rigidbody2D corpoPers;
    private Animator anim;
    private SpriteRenderer spritRend;
    //private UIManager iuManager;
     private Camera cam;

    [SerializeField] private float movHorizontal;
    [SerializeField] private float velocidadeMov=8f;
    [SerializeField] private float forcaPulo;
    [SerializeField] private float velobat=3f;
    [SerializeField] private bool segundoPulo, conta_pulo;

    [SerializeField] private int vidasAtual ;
    private bool estaPulando;

    // Start is called before the first frame update
    void Start()
    {
        corpoPers = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spritRend = GetComponent<SpriteRenderer>();
       // iuManager = FindObjectOfType<UIManager>();
       cam=FindObjectOfType(typeof(Camera))as Camera;

        vidasAtual = 3;

        velocidadeMov = 10;
        forcaPulo = 15;
    }

    // Update is called once per frame
    void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        Movimento();
        Pulo();
    }



    private void Movimento()
    {
        

        corpoPers.velocity = new Vector3(movHorizontal * velocidadeMov, corpoPers.velocity.y);


        if (movHorizontal > 0 ) 
        {
            spritRend.flipX = false;

            anim.SetBool("Correndo", true);
        }
        else if(movHorizontal < 0 )
        {
            spritRend.flipX = true;
            anim.SetBool("Correndo", true);

        }
        else if (movHorizontal == 0)
        {
            anim.SetBool("Correndo", false);

        }

    }

    private void Pulo()
    {
        
        if (Input.GetButtonDown("Jump"))
        {

            


            if (!estaPulando)
            {
                corpoPers.AddForce(new Vector2(corpoPers.velocity.x, forcaPulo), ForceMode2D.Impulse);
            }
            else
            {
                conta_pulo = true;
            }
            /*else if (segundoPulo)
            {

                corpoPers.AddForce(new Vector2(0f, (forcaPulo/2)), ForceMode2D.Impulse);
                segundoPulo = false;

            }*/


            


        }
    }


    void bufferDePulo()
    {

        if (conta_pulo)
        {

            corpoPers.AddForce(new Vector2(corpoPers.velocity.x, forcaPulo), ForceMode2D.Impulse);
            conta_pulo = false;

        }
        


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        //Obs: todos os colizores que estejam relacionados a base de pulo devem estar na layer 7
        if (collision.gameObject.layer == 7)
        {
            estaPulando = false;
            bufferDePulo();

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {

        //Obs: todos os colizores que estejam relacionados a base de pulo devem estar na layer 7
        if (collision.gameObject.layer == 7)
        {
            estaPulando = true;
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
        }
        void retorno(){
           Debug.Log("Hello World");
           velocidadeMov=8f;
           
        }
       
            }

