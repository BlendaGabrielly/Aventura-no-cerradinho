using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gameOver;
    public static GameController insta;
    private bool isPaused = false;

    void Start()
    {
        
         insta=this;
    }

    void Update()
    {
        
    }
   public void ShowGameOver(){
     gameOver.SetActive(true);
     Pause();
   }
    public void Restart(){
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     Debug.Log("Clicavel");
  }
    void Pause(){
        isPaused = true;
        Time.timeScale = 0f; 
    }
}
