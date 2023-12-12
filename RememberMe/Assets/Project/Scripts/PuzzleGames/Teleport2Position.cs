using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2Position : MonoBehaviour
{

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform destination;
    [SerializeField]
    GameObject vrPlayer;


      private void OnTriggerEnter(Collider other){

        if(other.tag == "Head"){
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            UnityEngine.Vector3 currPos = player.transform.position;
            Vector3 teleportPosition = new UnityEngine.Vector3(currPos.x ,currPos.y+5, currPos.z -3);
            player.transform.position = teleportPosition;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
