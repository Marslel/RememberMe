using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{

    public Transform chController;
    bool inside = false;
    public float speedUpDown = 0.2f;
    public PlayerMovementTutorial FPSInput;

    // Start is called before the first frame update
    void Start()
    {
        FPSInput = GetComponent<PlayerMovementTutorial>();
        inside = false;
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = false;
            inside = !inside;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Ladder")
        {
            FPSInput.enabled = true;
            inside = !inside;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inside == true && Input.GetKey("w"))
        {
            chController.transform.position += Vector3.up / speedUpDown;
        }
        if(inside == true && Input.GetKey("s"))
        {
            chController.transform.position += Vector3.down / speedUpDown;
        }
    }
}
