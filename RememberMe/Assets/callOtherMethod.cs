using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callOtherMethod : MonoBehaviour
{
[SerializeField]
GameObject gameobject;


private AlpacaPuzzleLogic script;

    


    // Start is called before the first frame update
    void Start()
    {
        script = gameobject.GetComponent<AlpacaPuzzleLogic>();
        if(script == null){
            Debug.Log("Script not found");
        }
    }

    public void callAlpacaPuzzleLogic(){
        script.updateAlpacaPuzzle();
    }

    
}
