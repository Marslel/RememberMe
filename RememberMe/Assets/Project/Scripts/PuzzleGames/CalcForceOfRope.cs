using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcForceOfRope : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    HingeJoint hinJoint;

    [SerializeField]
    Animation anim;
    int countBellRinging;

    [SerializeField]
    Collectables col;

    Vector3 startForce = new Vector3(0.0f, 0.0f, 0.0f);

    Vector3 curForce = new Vector3(0.0f, 0.0f, 0.0f);
    bool solved;


    void Start()
    {
        startForce = hinJoint.currentForce;
        countBellRinging = 0;
        solved = false;
        // anim = gameObject.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        // leave spin or jump to complete before changing
        if (anim.isPlaying)
        {
            return;

        }else{
            curForce = hinJoint.currentForce;
            if(curForce.z > startForce.z + 50){
                Debug.Log("Current force: " + curForce.z );
                anim.Play("Bell");
                countBellRinging ++;
            }
            if(!solved && countBellRinging == 3){
                    Debug.Log("You rang the bell 3 times you found a puzzle piece");
                    col.addPuzzlePiece();
                    solved = true;
            }
        }


    }
}
