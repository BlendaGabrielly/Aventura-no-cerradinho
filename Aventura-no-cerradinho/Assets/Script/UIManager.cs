using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] LifeHearts;

    public void UpdateLives(int lives){
        for(int i=0;i<LifeHearts.Length;i++){
            if(lives>i){
                LifeHearts[i].color=Color.white;

            }else{
                LifeHearts[i].color=Color.black;
            }
        }
    }
}
