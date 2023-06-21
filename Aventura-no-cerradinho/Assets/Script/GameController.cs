using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public static GameController insta;

    void Start()
    {
        
         insta=this;
    }

    void Update()
    {
        
    }
   public void ShowGameOver(){
     gameOver.SetActive(true);
   }
  public void teste(){
    Debug.Log("testeee");
  }
  public void Restart(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
