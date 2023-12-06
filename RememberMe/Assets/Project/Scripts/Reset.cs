using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    [SerializeField]
    public Data_Storage data_Storage;
    // Start is called before the first frame update
    void Start()
    {
        //reset all data storage settings
        data_Storage.time = 0;
        data_Storage.puzzlesSolved = 0;
        data_Storage.mazeWon = false;
        data_Storage.shootingRangeWon = false;
        data_Storage.pianoWon = false;
        data_Storage.balloon = false;
        data_Storage.chess = false;
        data_Storage.alpaca = false;
        data_Storage.bell = false;
        data_Storage.level = 0;
        data_Storage.MazePrefabs.Clear();
        data_Storage.MazepPrefabIndex = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
