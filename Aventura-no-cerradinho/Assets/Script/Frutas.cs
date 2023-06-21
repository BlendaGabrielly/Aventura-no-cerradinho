using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frutas : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public  GameObject card;

    private bool isPaused = false;

    void Start()
    {
        sr=GetComponent<SpriteRenderer>();
        sr.enabled=true;
        
        circle=GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            Continuar();
            Debug.Log("Teste");
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag=="Player"){
           sr.enabled=false;
           circle.enabled=false;
           Destroy(gameObject,0.25f);
           Pause();
           card.SetActive(true);
        }
    }
    void Pause(){
        isPaused = true;
        Time.timeScale = 0f; 
    }
    public void Continuar(){
        isPaused = false;
        Time.timeScale = 1f;
        card.SetActive(false);
    }
}
