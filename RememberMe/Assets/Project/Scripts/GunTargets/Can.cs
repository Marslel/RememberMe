using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other){
        Debug.Log("Trigger durchdrungen von: " + other.name);
    }
}
