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
    private SteamVR_Input_Sources righthand;
    private SteamVR_Input_Sources lefthand;
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
    private LevelSettings levelsettings;
    private ChangeScene changeScene;
    private int selectedLevel;

    
    // Start is called before the first frame update
    void Start()
    {
        righthand = SteamVR_Input_Sources.RightHand;
        lefthand = SteamVR_Input_Sources.LeftHand;
        textIndex = 0;
        timer = Time.time;
        levelsettings = GetComponent<LevelSettings>();
        changeScene = GetComponent<ChangeScene>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //if button a pressed initate button "weiter"
        if (buttonNext.GetStateDown(righthand) || buttonNext.GetStateDown(lefthand) || Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Button A pressed");
            if(textIndex == texts.Length-1){
                // set level and switch to mainscene
                Debug.Log("Button A pressed - last screen");
                switch(selectedLevel) {
                    case 0:
                         levelsettings.setLevel1();
                         break;
                    case 1:
                        levelsettings.setLevel2();
                        break;
                    case 2:
                        levelsettings.setLevel3();
                        break;
                    default:
                        levelsettings.setLevel1();
                        break;
                }
                
                changeScene.LoadOtherScene();

                
            }
            ShowNextText();

        }else if(buttonBack.GetStateDown(righthand) || buttonBack.GetStateDown(lefthand)){
            Debug.Log("Button B pressed");
            ShowPreviousText();
        }

        Vector2 joystickInput = joystick.GetAxis(righthand);

        //timer -= Time.deltaTime;
        if (timer < Time.time)
        {
            antispam = false;
        }

        if(joystickInput.y != 0 && !antispam){
            Debug.Log("Joystick gedrueckt");
                buttonindex = (buttonindex + level.Length - (int)joystickInput.y) % level.Length;
                if(textIndex == texts.Length-1){
                    for(int i = 0; i < level.Length; i++){
                        if(i==buttonindex){
                            level[i].GetComponent<Image>().color = Color.green;
                            selectedLevel = i;
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
        Debug.Log("Show Text");
        if(textIndex < texts.Length-1){
            textIndex ++;
            texts[textIndex-1].SetActive(false);
            texts[textIndex].SetActive(true);
            Debug.Log("Set Text");
            if(textIndex == texts.Length-1){
                Debug.Log("Button nicht da");
                nextButton.gameObject.SetActive(false);
                startButton.gameObject.SetActive(true);
                Debug.Log("Button jetzt");

                // for(int i = 0; i < level.Length; i++){
                //     if(i==buttonindex){
                //         level[i].GetComponent<Image>().color = Color.green;
                //     }else{
                //         level[i].GetComponent<Image>().color = Color.white;
                //     }
                // }
            }
        }

    }

    void ShowPreviousText(){
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
