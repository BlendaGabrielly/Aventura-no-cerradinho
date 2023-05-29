using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
   [Header("Camera")]
    Vector3 cameraInfinta;
    public float shakeMagnitude=0.05f;
    public float shakeTime=0.5f;
    public Camera mainCamera;
    
    public void ShakeIt(){
        cameraInfinta=mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking",0f,0.005f);
        Invoke("StopCameraShaking",shakeTime);
    }
    void StartCameraShaking(){
      float cameshakingX=Random.value*shakeMagnitude*2-shakeMagnitude;
      float cameshakingY=Random.value*shakeMagnitude*2-shakeMagnitude;
      Vector3 cameraPosition=mainCamera.transform.position;

      cameraPosition.x+=cameshakingX;
      cameraPosition.y+=cameshakingY;
      mainCamera.transform.position=cameraPosition;
    }
    void StopCameraShaking(){
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position=cameraInfinta;
}
}



