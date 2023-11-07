using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcForceOfRope : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    HingeJoint hingeJoint;

    [SerializeField]
    Animation anim;


    Vector3 startForce = new Vector3(0.0f, 0.0f, 0.0f);

    Vector3 curForce = new Vector3(0.0f, 0.0f, 0.0f);


    void Start()
    {
        startForce = hingeJoint.currentForce;
        // anim = gameObject.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        // leave spin or jump to complete before changing
        if (anim.isPlaying)
        {
            return;
        }

        curForce = hingeJoint.currentForce;
        if(curForce.z > startForce.z + 50){
            Debug.Log("Current force: " + curForce.z );
            anim.Play("Bell");
        }
    }
}
