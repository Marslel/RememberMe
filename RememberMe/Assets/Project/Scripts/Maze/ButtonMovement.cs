using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{

    [SerializeField] 
    GameObject button;
    [SerializeField] 
    Collider wall;
    [SerializeField] 
    Animation anim;

    UnityEngine.Vector3 buttonPos;

    bool activated;

    private void OnTriggerEnter(Collider other)
    {

        if(other != wall && !activated){
            activated = true;
            anim.Play();
            //buttonPos = new UnityEngine.Vector3(73.9f,-67.81284f,3.069515f);
            button.transform.position = buttonPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
