using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToRigidBody : MonoBehaviour
{
    public string tagToAdd;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other){

        if(other.transform.CompareTag(tagToAdd)){
            other.transform.SetParent(transform);
        }
    }
}
