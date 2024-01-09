using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreFallingItem : MonoBehaviour
{

    private Vector3 startPos;

    [SerializeField]
    bool spawnInFront;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1){
            
            if(!spawnInFront){
                // place at origin
                transform.position = startPos;
            }else{
                transform.position = new Vector3 (transform.position.x,4f,transform.position.z);
            }

        }
    }
}
