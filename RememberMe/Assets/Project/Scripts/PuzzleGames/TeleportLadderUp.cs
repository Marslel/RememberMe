using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLadderUp : MonoBehaviour
{

    UnityEngine.Vector3 teleportPosition;


    private void OnTriggerEnter(Collider other){

        if(other.tag == "Player"){
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            UnityEngine.Vector3 currPos = player.transform.position;
            teleportPosition = new UnityEngine.Vector3(currPos.x ,currPos.y + 6, currPos.z -2);
            player.transform.position = teleportPosition;
        }

    }
    
}
