using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //public static GameController insta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart(string lvlName)
    {
        Debug.Log("clicou");
        SceneManager.LoadScene(lvlName);
        
    }

}
