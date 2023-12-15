using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTheGame : MonoBehaviour
{
    public int difficulty = 3;
    public int points;
    public Data_Storage data;


   
    public void collectPoints(){
        points++;
        Debug.Log("Add Points: " + points);
        if(enoughPoints(points)){
            Debug.Log("Win Game");
            data.updateShootingRangeWon(true);
            data.updatePuzzlesSolved(1);
            SceneManager.LoadScene("MainScene");
        }
    }

    public bool enoughPoints(int points){
        if(points >= difficulty){
            return true;
        }
        return false;
    }
}
