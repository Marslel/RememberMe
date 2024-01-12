using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class WinTheGame : MonoBehaviour
{
    public int level;
    public int points;
    public Data_Storage data;
    [SerializeField]
    public Text timeText;

    public SpawnBullet spawnBullet;

    public EndLine endLine;

    void Start()
    {
         // adapt puzzles solved on ui
        timeText.text = data.puzzlesSolved.ToString();

        level = data.level;
    }
   
    public void collectPoints(){
        points++;
        Debug.Log("Add Points: " + points);
        if(enoughPoints(points)){
            Debug.Log("Win Game");
            data.updateShootingRangeWon(true);
            data.updatePuzzlesSolved(1);
            endLine.PlayVoiceLine();
            data.missedShots = data.missedShots + spawnBullet.maxBullets - spawnBullet.shootBullets;
        }else if (spawnBullet.shootBullets == spawnBullet.maxBullets){
            data.shootingTries++;
            data.missedShots = data.missedShots + spawnBullet.maxBullets - spawnBullet.shootBullets;
            points = 0;
        }
    }

    public bool enoughPoints(int points){
        switch (level)
        {
            case 1:
                if(points == 3){
                    return true;
                }else{
                    return false;
                }
            
            case 2:
                if(points == 5){
                    return true;
                }else{
                    return false;
                }

            case 3:
                if(points == 8){
                    return true;
                }else{
                    return false;
                }
        }
        return false;
    }

    
}
