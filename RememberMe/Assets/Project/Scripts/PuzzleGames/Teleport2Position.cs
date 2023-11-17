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


    void OnTriggerEnter(Collider other){
        if(other == vrPlayer.GetComponent<Collider>()){
            player.position = destination.position;
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
