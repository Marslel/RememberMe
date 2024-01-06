using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem{
public class SwitchScreensUI : MonoBehaviour
{
    public SteamVR_Action_Boolean buttonNext = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ButtonNext");
    public SteamVR_Action_Boolean buttonBack = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ButtonBack");
    public SteamVR_Action_Vector2 joystick = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Joystick");
    private SteamVR_Input_Sources handType;
    public Button nextButton;
    public Button backButton;
    public Button startButton;
    public Button[] level;
    private int buttonindex;
    private int textIndex;
    [SerializeField]
    public GameObject[] texts;
    [SerializeField]
    public Data_Storage data_Storage;
    public float time = 2.0f;
    public float timer;
    private bool antispam = false;

    
    // Start is called before the first frame update
    void Start()
    {
        handType = SteamVR_Input_Sources.RightHand;
        textIndex = 0;
        timer = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {

        //if button a pressed initate button "weiter"
        if (buttonNext.GetStateDown(handType)){
            ShowNextText();

        }else if(buttonBack.GetStateDown(handType)){
            ShowPreviousText();
        }

        Vector2 joystickInput = joystick.GetAxis(handType);

        //timer -= Time.deltaTime;
        if (timer < Time.time)
        {
            antispam = false;
        }

        if(joystickInput.y != 0 && !antispam){
                Debug.Log("You have scrolled " + joystickInput.y);
                buttonindex = (buttonindex + level.Length - (int)joystickInput.y) % level.Length;
                Debug.Log("ahhhhhhhhhh  " + buttonindex);
                if(textIndex == texts.Length-1){
                    for(int i = 0; i < level.Length; i++){
                        if(i==buttonindex){
                            level[i].GetComponent<Image>().color = Color.green;
                        }else{
                            level[i].GetComponent<Image>().color = Color.white;
                        }
                    }
                }
                antispam = true;
                timer = Time.time + 0.5f;
            }
        
        
    }

    void ShowNextText(){
        Debug.Log("You have clicked the next button!");

        if(textIndex < texts.Length-1){
            textIndex ++;
            texts[textIndex-1].SetActive(false);
            texts[textIndex].SetActive(true);

            if(textIndex == texts.Length-1){
                nextButton.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);

                for(int i = 0; i < level.Length; i++){
                    if(i==buttonindex){
                        level[i].GetComponent<Image>().color = Color.green;
                    }else{
                        level[i].GetComponent<Image>().color = Color.white;
                    }
                }
            }
        }

    }

    void ShowPreviousText(){
        Debug.Log("You have clicked the back button!");
         if(textIndex == texts.Length-1){
            nextButton.gameObject.SetActive(true);
                startButton.gameObject.SetActive(false);
         }
        if(textIndex > 0){
            textIndex --;
        }
        texts[textIndex+1].SetActive(false);
        texts[textIndex].SetActive(true);
    }
}
}
