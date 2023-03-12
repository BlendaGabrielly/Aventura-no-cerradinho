using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 8f;
    public float forcaPulo = 8f;

    public bool estaPulando, segundoPulo;

    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
   

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

        if(Input.GetAxis("Horizontal") >= 0)
        {
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
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            estaPulando = true;
            anim.SetBool("Pulando", true);

        }

    }







}
