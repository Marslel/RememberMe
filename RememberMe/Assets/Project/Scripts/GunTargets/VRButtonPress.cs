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
        // Start is called before the first frame update
        void Start()
        {
        handType = SteamVR_Input_Sources.RightHand;
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
                    exitText.SetActive(true);
                    exitButton.SetActive(true);
                }else{
                    exitText.SetActive(false);
                    exitButton.SetActive(false);
                }    
            }
        }
    }
}