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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("irgendways gefunden auf zur Shooting Range :" + other.tag + other.name);
        if(other.tag == "Head" && data_Storage.shootingRangeWon == false){

            Debug.Log("Player gefunden auf zur Shooting Range");
                SceneManager.LoadScene(sceneName);
            
        }
    }

    public void LoadOtherScene(){
        SceneManager.LoadScene(sceneName);
    }
}
