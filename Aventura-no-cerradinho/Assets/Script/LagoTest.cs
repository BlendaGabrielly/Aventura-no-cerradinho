using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagoTest : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){


        if (collision.gameObject.tag == "Player") {
            GameController.insta.ShowGameOver();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
     }
}
