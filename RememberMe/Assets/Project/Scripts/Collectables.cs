using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    List<GameObject> puzzleObjects = new List<GameObject>();

    [SerializeField]
    GameObject alpacaTreat;

    public bool treatCollected;
    public bool alpacaIgnorePlayer;

    [SerializeField]
    public Data_Storage data_Storage;
    [SerializeField]
    public GameObject time;

    ArrayList puzzleparts = new ArrayList();
    int countPiece;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        countPiece = 0;
        treatCollected = false;
        alpacaIgnorePlayer = false;
        if(data_Storage.alpaca){
            alpacaIgnorePlayer = true;
        }  
        for(int i = 0; i <data_Storage.puzzlesSolved ; i++){
            addPuzzlePiece();
        }  
    }

    // Update is called once per frame
    void Update()
    {
        //update the remaining time in Data Storage scriptable Object
        if(data_Storage != null){
            data_Storage.time = time.GetComponent<Timer>().timeRemaining;
        }
        
    }


    public void addPuzzlePiece(){
        Debug.Log("You found a puzzle part");

        Instantiate(puzzleObjects[countPiece], new Vector3(3, 10, 8), Quaternion.identity);
        countPiece ++;
    }

    public void collectTreat(){
        treatCollected = true;
         Debug.Log("You found an alpaca treat");
        
    }
}


