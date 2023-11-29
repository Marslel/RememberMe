using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTheGame : MonoBehaviour
{
    public static WinTheGame Instance;
    public int difficulty;
    public int points{ get; private set;}

    private void Avake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    public void collectPoints(){
        points++;
        Debug.Log("Add Points");
        if(enoughPoints(points)){
            Debug.Log("Win Game");
        }
    }

    public bool enoughPoints(int points){
        if(points >= difficulty){
            return true;
        }
        return false;
    }
}
