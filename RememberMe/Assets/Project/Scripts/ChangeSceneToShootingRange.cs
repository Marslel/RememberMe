using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToShootingRange : MonoBehaviour
{
        // name of the new scene
    [SerializeField]
    string sceneName;
    [SerializeField]
    Scene main;
    [SerializeField]
    public Data_Storage data_Storage;
    private Scene currentScene;

    [SerializeField]
    public GameObject time;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other){
       
        if(other.tag == "Head" && data_Storage.shootingRangeWon == false){

                SceneManager.LoadScene(sceneName);
            
        }else if(other.tag == "Head" && currentScene.name == "ShootingRange"){

            data_Storage.time = time.GetComponent<Timer>().timeRemaining;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadOtherScene(){
        SceneManager.LoadScene(sceneName);
    }
}
