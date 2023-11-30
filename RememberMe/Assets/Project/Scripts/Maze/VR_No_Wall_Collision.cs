using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_No_Wall_Collision : MonoBehaviour
{
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] float fadeSpeed;
    [SerializeField] float sphereCheckSize = 0.15f;

    private Material cameraFadeMaterial;
    private bool isCameraFadedOut = false;
    private void Awake() => cameraFadeMaterial = GetComponent<Renderer>().material;

    // Update is called once per frame
    void Update()
    {
        // collide with the wall -> fade out the camera to black
        if(Physics.CheckSphere(transform.position, sphereCheckSize, collisionLayer, QueryTriggerInteraction.Ignore)){
            cameraFade(1f);
            isCameraFadedOut = true;
            print("i hit the wall");
        }else{
            if(!isCameraFadedOut){
                return;
            }
            cameraFade(0f);

        }

    }

    public void cameraFade(float wallvalue){
        var fadeValue = Mathf.MoveTowards(cameraFadeMaterial.GetFloat("_wallvalue"), wallvalue, Time.deltaTime * fadeSpeed);
        cameraFadeMaterial.SetFloat("_wallvalue", fadeValue);

        //camera back to normal
        if(fadeValue <= 0.01f){
            isCameraFadedOut = false;
        }
    }

}
