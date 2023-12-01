using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTheGame : MonoBehaviour
{
    private static WinTheGame _Instance;
    public int difficulty = 6;
    public int points{ get; private set;}

    public static WinTheGame Instance{
        get{
            if(_Instance == null){
                GameObject go = new GameObject("WinTheGame");
                _Instance = go.AddComponent<WinTheGame>();
            }
            return _Instance;
        }
    }
    public void collectPoints(){
        points++;
        Debug.Log("Add Points: " + points);
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
