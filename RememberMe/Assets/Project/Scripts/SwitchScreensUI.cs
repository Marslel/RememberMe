using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem{
public class SwitchScreensUI : MonoBehaviour
{
    public SteamVR_Action_Boolean buttonNext = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ButtonNext");
    public SteamVR_Action_Boolean buttonBack = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ButtonBack");
    public SteamVR_Action_Boolean joystick = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Joystick");
    private SteamVR_Input_Sources handType;
    public Button nextButton;
    public Button backButton;

    public Button[] level;
    private int textIndex;
    [SerializeField]
    public GameObject[] texts;
    
    // Start is called before the first frame update
    void Start()
    {
        handType = SteamVR_Input_Sources.RightHand;
        textIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        //if button a pressed initate button "weiter"
        if (buttonNext.GetStateDown(handType))
        {
            nextButton.onClick.AddListener(ShowNextText);
        }else if(buttonBack.GetStateDown(handType)){
            backButton.onClick.AddListener(ShowPreviousText);
        }
        
    }

    void ShowNextText(){
        Debug.Log("You have clicked the next button!");
        if(texts.Length <= textIndex){
            textIndex ++;
        }
        texts[textIndex-1].SetActive(false);
        texts[textIndex].SetActive(true);
    }

    void ShowPreviousText(){
        Debug.Log("You have clicked the back button!");
        if(textIndex >= 0){
            textIndex --;
        }
        texts[textIndex+1].SetActive(false);
        texts[textIndex].SetActive(true);
    }
}
}
