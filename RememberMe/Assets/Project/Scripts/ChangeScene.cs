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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other){
        Debug.Log("irgebndways gefunden auf zum Maze :" + other.tag + other.name);
        if(other.tag == "Head"){

            Debug.Log("Player gefunden auf zum Maze");
                SceneManager.LoadScene(sceneName);
            
        }
    }

}
