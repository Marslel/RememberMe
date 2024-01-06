using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEndScene : MonoBehaviour
{
    [SerializeField]
    Data_Storage data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerExit(Collider other){

          if(other.tag == "Head" && (data.puzzlesSolved == 7 || (data.level ==1 && data.puzzlesSolved >= 5))){

            // go to happy end scene
            SceneManager.LoadScene("EndSceneHappyEnd");

          }
    }
}
