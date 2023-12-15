using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float timeRemaining;
    [SerializeField]
    public bool timerIsRunning = false;
    [SerializeField]
    public Text timeText;
    [SerializeField]
    string sceneName;
    [SerializeField]
    public Data_Storage data_Storage;

    
    [SerializeField]
    Skybox sky;

    Scene main;
    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

        //check if it's Maze scene -> adapt to totaltime if neccessary
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Maze"){
            float totaltime = data_Storage.time;
            timeRemaining = data_Storage.mazetime;
            if(totaltime < timeRemaining){
                timeRemaining = totaltime;
            }
        }else if(currentScene.name == "Mainscene"){
            timeRemaining = data_Storage.time;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                displayTime(timeRemaining);
                if(timeRemaining <= 5300.0 && timeRemaining >= 5298.0){
                    sky.changeSkyboxMaterial(1);
                }
                if (timeRemaining <= 5200.0&& timeRemaining >= 5198.0){
                    sky.changeSkyboxMaterial(2);
                }
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                
                SceneManager.LoadScene(sceneName);
            
        
            }
        }
    }

    void displayTime(float time){
        time += 1;
        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
