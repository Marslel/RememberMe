using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data_Storage", menuName = "RememberMe/Data_Storage", order = 0)]
public class Data_Storage : ScriptableObject {

    /// <summary>
    /// Data storage for Achievements in the game
    /// </summary>
     [SerializeField] public int puzzlesSolved = 0;
     [SerializeField] public bool mazeWon = false;
     [SerializeField] public bool shootingRangeWon = false;
     [SerializeField] public bool pianoWon = false;

    /// riddles in main scene
     [SerializeField] public bool balloon = false;
     [SerializeField] public bool chess = false;
     [SerializeField] public bool bell = false;
     [SerializeField] public bool alpaca = false;
     [SerializeField] public bool alpacaTreat = false;

     [SerializeField] public float time;

     public void updatePuzzlesSolved(int num){
            puzzlesSolved += num;
     }

     public void updateMazeWon(bool won){
            mazeWon = won;
     }
    
     public void updateShootingRangeWon(bool won){
            shootingRangeWon = won;
     }

     public void updateMainScene(bool piano, bool balloon, bool chess, bool bell, bool alpaca){
            this.pianoWon = piano;
            this.balloon = balloon;
            this.chess = chess;
            this.bell = bell;
            this.alpaca = alpaca;
     }

     public void adaptTimer(float timeToReduce){
       time -= timeToReduce;
     }

}
