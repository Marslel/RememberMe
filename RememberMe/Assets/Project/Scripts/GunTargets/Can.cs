using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Bullet")){
            Debug.Log("Kollision mit: " + collision.gameObject.name);
            WinTheGame.Instance.collectPoints();
            Debug.Log("Punkte: " + WinTheGame.Instance.points);
        } 
        StartCoroutine(StartCooldown());  
    }

    IEnumerator StartCooldown(){
        yield return new WaitForSeconds(2);
    }
}
