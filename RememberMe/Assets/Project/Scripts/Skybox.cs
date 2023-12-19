using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skybox : MonoBehaviour
{
    
    [SerializeField]
    List<Material> skyMaterial;
    [SerializeField]
    int startIndex;
    [SerializeField]
    Data_Storage data; 

    [SerializeField]
    Light sunlight;

    Color lightsky = new Color(1f,0.9528302f,0.7877358f);
    Color eveningsky = new Color(0.2830189f,0.2678889f,0.2149342f);
    Color darksky = new Color(0,0,0);


    int currIndex;


    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Maze"){
            currIndex = startIndex;
            if(data.level == 3){
                currIndex = 2;
            }
        
            changeSettings();
        }else{
            currIndex = startIndex;
            changeSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        

    }

/// <summary>
/// 
/// </summary>
/// <param name="number"> number of the material (0 -> daylight ; 1 -> night)</param>
    public void changeSkyboxMaterial(int number){
        if(number != currIndex){
            currIndex = number;
            changeSettings();

        }
        
    }


    private void changeSettings(){
        RenderSettings.skybox = skyMaterial[currIndex];
        switch(currIndex)
        {
            case 0:
                sunlight.color = lightsky;
                break;
            case 1:
                sunlight.color = darksky;
                break;
            case 2: 
                sunlight.color = eveningsky;
                break;

            default:
                break;
            
        }
    }
}
