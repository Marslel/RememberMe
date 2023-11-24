using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteractable : MonoBehaviour
{

    /*
   public void Interact(){
        Debug.Log("Hand touched");
    }
  */


     public void OnTriggerEnter(Collider other){

        Debug.Log("Hand touched!");
     }

}

