using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cenario : MonoBehaviour
{
    public List<GameObject> platforms=new List<GameObject>();//prefab
    public List<Transform> currentPlat=new List<Transform>();//objetos instanciados
    public int offset;
 
    private Transform player;
    private Transform currentPlatsPoint;
    public int plataformaIndex;
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        for(int i=0;i<platforms.Count;i++){
            Transform p = Instantiate(platforms[i],new Vector3(i*52,0,0),transform.rotation).transform;
            currentPlat.Add(p);
            offset+=52;
        }
       currentPlatsPoint=currentPlat[plataformaIndex].GetComponent<PointE>().point;
    }
    public GameObject myplat;
    void Update(){  
        if(Input.GetKeyDown(KeyCode.A)){
            Recycle(myplat);
            }
       float distance=player.position.x-currentPlatsPoint.position.x;
       //Debug.Log(distance);
       if(distance>=5){
        Recycle(currentPlat[plataformaIndex].gameObject);
        plataformaIndex++;
        if(plataformaIndex>currentPlat.Count-1){
            plataformaIndex=0;
        }

        currentPlatsPoint=currentPlat[plataformaIndex].GetComponent<PointE>().point;
       }
    }
    
    public void Recycle(GameObject platform){
       platform.transform.position=new Vector3(offset,0,0);
       offset+=52;//ultima plataforma

    }
}
