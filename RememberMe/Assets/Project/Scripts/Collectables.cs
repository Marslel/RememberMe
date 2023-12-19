using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    List<GameObject> puzzleObjects = new List<GameObject>();
    
    private List<Vector3> puzzlePos = new List<Vector3>();
    private Vector3 puzzleRot;

    [SerializeField]
    GameObject alpacaTreat;


    [SerializeField]
    List <GameObject> chessboards;

    public bool treatCollected;
    public bool alpacaIgnorePlayer;

    [SerializeField]
    NPCInteractable pablo;

    [SerializeField]
    public Data_Storage data_Storage;
    [SerializeField]
    public GameObject time;

    ArrayList puzzleparts = new ArrayList();
    int countPiece;
    // Start is called before the first frame update
    void Start()
    {

        addPuzzlePosAndRot();

        
        switch (data_Storage.level){
            case 1:
                Instantiate(chessboards[0], new Vector3(-25.47f, -0.83f, 11.28976f), Quaternion.identity);
                break;
            case 2:
                Instantiate(chessboards[1], new Vector3(-25.47f, -0.83f, 11.28976f), Quaternion.identity);
                break;
            case 3:
                Instantiate(chessboards[2], new Vector3(-25.47f, -0.83f, 11.28976f), Quaternion.identity);
                break;
            default:
                break;
        }
        
        countPiece = 0;
        treatCollected = false;
        alpacaIgnorePlayer = false;
        if(data_Storage.alpaca){
            alpacaIgnorePlayer = true;
        }  
        for(int i = 0; i <data_Storage.puzzlesSolved ; i++){
            Instantiate(puzzleObjects[countPiece], puzzlePos[countPiece], Quaternion.Euler(puzzleRot));
            countPiece ++;
            pablo.dialogueIndex ++;
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

        Instantiate(puzzleObjects[countPiece], puzzlePos[countPiece], Quaternion.Euler(puzzleRot));
        countPiece ++;
        data_Storage.puzzlesSolved ++;
        pablo.dialogueIndex ++;

        
        
    }

    public void collectTreat(){
        treatCollected = true;
         Debug.Log("You found an alpaca treat");
        
    }

    private void addPuzzlePosAndRot(){
        puzzleRot = new Vector3(0f,90f,270f);
        puzzlePos.Add(new Vector3(7.4f,2f,17.3883f));
        puzzlePos.Add(new Vector3(7.9f,2f,17.3883f));
        puzzlePos.Add(new Vector3(8.4f,2f,17.3883f));
        puzzlePos.Add(new Vector3(7.4f,1.5f,17.3883f));
        puzzlePos.Add(new Vector3(7.9f,1.5f,17.3883f));
        puzzlePos.Add(new Vector3(8.4f,1.5f,17.3883f));
        puzzlePos.Add(new Vector3(7.9f,1.1f,17.3883f));
    }
}


