using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteObj : MonoBehaviour
{
    public GameObject objetoPrefab;
    public Vector3 limiteMin;
    public Vector3 limiteMax;

    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject point;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
        circle = GetComponent<CircleCollider2D>();
        Invoke("InstanciarObjeto", 1f);
        Vector3 posicaoInicial = point.transform.position;
       // Debug.Log("Posição inicial: " + posicaoInicial);
    }
     private void Update()
    {
        // Obter a localização atualizada do objeto a cada quadro
        Vector3 posicaoAtual = point.transform.position;
        //Debug.Log("Posição atual: " + posicaoAtual);
    }

    void InstanciarObjeto()
    {
        //Debug.Log("entrou");
        //float posX = point.transform.position.x;
        // Instanciar objeto em posição aleatória
        Vector3 posicaoAleatoria = new Vector3(
            Random.Range(limiteMin.x, limiteMax.x),
            Random.Range(limiteMin.y, limiteMax.y),
            Random.Range(limiteMin.z, limiteMax.z));
        Instantiate(objetoPrefab, posicaoAleatoria, Quaternion.identity);
        Destroy(objetoPrefab, 5f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //if(collider.gameObject<2)
            sr.enabled = false;
            circle.enabled = false;
            Destroy(gameObject, 0.25f);
            
        }
    }
}
