using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteMov : MonoBehaviour
{

    private Rigidbody2D corpoPers;
    private Animator anim;
    private SpriteRenderer spritRend;
    private UIManager iuManager;

    [SerializeField] private float movHorizontal;
    [SerializeField] private float velocidadeMov;
    [SerializeField] private float forcaPulo;
 
    [SerializeField] private int vidasAtual;
    private bool estaPulando;

    // Start is called before the first frame update
    void Start()
    {
        corpoPers = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spritRend = GetComponent<SpriteRenderer>();
        iuManager = FindObjectOfType<UIManager>();

        vidasAtual = 3;

        velocidadeMov = 10;
        forcaPulo = 15;
    }

    // Update is called once per frame
    void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        Movimento();
    }



    private void Movimento()
    {
        Pulo();

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
           


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Obs: todos os colizores que estejam relacionados a base de pulo devem estar na layer 7
        if (collision.gameObject.layer == 7)
        {
            estaPulando = false;

        }


    }

    void OnCollisionExit2D(Collision2D collision)
    {

        //Obs: todos os colizores que estejam relacionados a base de pulo devem estar na layer 7
        if (collision.gameObject.layer == 7)
        {
            estaPulando = true;
        }

    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        //if(invincible){
        // return;
        //}
        if (collider.gameObject.tag == "Arbusto")
        {
            vidasAtual--;
            iuManager.UpdateLives(vidasAtual);

            // anim.SetTrigger("Andando");
            //velocidade = (float)(velocidade - (velocidade * 0.2));
            if (vidasAtual <= 0)
            {

                GameController.insta.ShowGameOver();
                Destroy(this.gameObject);
            }
            else
            {
                //StartCoroutine(Blinking(invincibleTime));
            }
        }

    }


}
