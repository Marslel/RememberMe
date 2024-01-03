using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    // name of the new scene
    [SerializeField]
    string sceneName;
    [SerializeField]
    Scene main;
    [SerializeField]
    public Data_Storage data_Storage;

    private Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("irgendways gefunden auf zum Maze :" + other.tag + other.name);
        if(other.tag == "Head" && data_Storage.mazeWon == false){

            Debug.Log("Player gefunden auf zum Maze");
                SceneManager.LoadScene(sceneName);
            
        }else if(other.tag == "Head" && currentScene.name == "Maze"){
            Debug.Log("Player gefunden , raus aus dem Maze");
                SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadOtherScene(){
        SceneManager.LoadScene(sceneName);
    }

}
