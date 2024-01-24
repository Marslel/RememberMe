using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem{
public class ShowExitScreen : MonoBehaviour
{
    public SteamVR_Action_Boolean buttonMenu = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ButtonMenu");
    private SteamVR_Input_Sources handType;
    private bool menuVisible;
    public GameObject exitText;
    public GameObject exitButton;
    public GameObject map;
    public GameObject exitText2;
    GameObject player;

    public Camera mainCamera;
    public GameObject menuScreen;
    // Start is called before the first frame update
    void Start()
    {
       handType = SteamVR_Input_Sources.RightHand;
       player =  GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        // Change the ButtonMask to access other inputs
        if (buttonMenu.GetStateDown(handType))
        {
            menuVisible = !menuVisible;
            Debug.Log("Trigger down");

            if(menuVisible){
                //set location of menu in front of player coordinates
                //Vector3 distanceToPlayer = new Vector3(0.5f,1,0);
                menuScreen.transform.position = mainCamera.transform.forward + mainCamera.transform.position;
                //menuScreen.transform.LookAt(player.transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
                Vector3 relativePos = mainCamera.transform.position - menuScreen.transform.position;
                menuScreen.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);

                exitText.SetActive(true);
                exitButton.SetActive(true);
                exitText2.SetActive(true);
                map.SetActive(true);
            }else{
                exitText.SetActive(false);
                exitButton.SetActive(false);
                exitText2.SetActive(false);
                map.SetActive(false);
            }    
        }
    }
}
}
