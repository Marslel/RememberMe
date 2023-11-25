using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Game_Status : MonoBehaviour
{

    public Data_Storage data_Storage;
    // Start is called before the first frame update
    void Start()
    {
        if(data_Storage != null){
            data_Storage.updateMazeWon(true);
            data_Storage.updatePuzzlesSolved(1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Puzzles Solved: "+ data_Storage.puzzlesSolved);
    }
}
