using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem{
public class MoveWithButton : MonoBehaviour
{
    GameObject player;
    public SteamVR_Action_Boolean forward = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Forward");
    public SteamVR_Action_Boolean right = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Right");
    public SteamVR_Action_Boolean left = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Left");
    public SteamVR_Action_Boolean backward = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Backward");
    private SteamVR_Input_Sources handType;
    // Start is called before the first frame update
    void Start()
    {
         handType = SteamVR_Input_Sources.RightHand;
         player =  GameObject.FindGameObjectWithTag("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (forward.GetStateDown(handType)){
            Vector3 forMove = player.transform.forward;
            forMove = forMove + new Vector3(1,0,0);
            player.transform.position += forMove;
        }else if(right.GetStateDown(handType)){
            Vector3 rightMove = player.transform.forward;
            rightMove = rightMove * (3);
            rightMove = rightMove + new Vector3(1,0,0);
            player.transform.position += rightMove;
            
        }else if(left.GetStateDown(handType)){
            Vector3 leftMove = new Vector3();
        }else if(backward.GetStateDown(handType)){
            Vector3 backMove = new Vector3();
        }
        
    }
}
}
