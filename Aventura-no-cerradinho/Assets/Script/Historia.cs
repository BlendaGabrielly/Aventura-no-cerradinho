using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{
    public GameObject[] historia;
    int index;

    void Start()
    {
        index=0;
    }
    void Update()
    {
       if(index>=14){
         index=14; 
    }
       if(index<=0){
         index=0;
       }
       if(index==0){
          historia[0].SetActive(true);
       }
    }
 public void Next(){
    index+=1;
    for(int i=0;i<historia.Length;i++){
        historia[i].SetActive(false);
        historia[index].SetActive(true);
    }
    Debug.Log(index);
}
 public void Previous(){
     index-=1;
    for(int i=0;i<historia.Length;i++){
        historia[i].SetActive(false);
        historia[index].SetActive(true);
    }
    Debug.Log(index);
 }
}
