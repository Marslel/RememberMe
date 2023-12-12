using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessLogic : MonoBehaviour
{
    [SerializeField]
    ResetChessBoard resetChess;
    [SerializeField]
    GameObject chessPrefab;

    [SerializeField]
    GameObject chessPlayer;
    ChessPlayer cp;

    [SerializeField] 
    GameObject endTile; 
    
    [SerializeField]
    List<GameObject> whitePlayers = new List<GameObject>();
    
    [SerializeField]
    List<GameObject> blackPlayers = new List<GameObject>();
    
    [SerializeField]
    Collectables col;
    [SerializeField]
    Data_Storage dataStorage;

    List<Vector3> startPosBlack;
    List<Quaternion> startRotBlack;
    
    int startX;
    int startY;
    float distance;
    bool solved;
    Vector3 startPos;
    Quaternion startRot;


    ChessTile endTilePiece;

    // Start is called before the first frame update
    void Start()
    {   
        solved = dataStorage.chess;
        cp = chessPlayer.GetComponent<ChessPlayer>();
        endTilePiece = endTile.GetComponent<ChessTile>();
        startPosBlack = new List<Vector3>();
        startRotBlack = new List<Quaternion>();
        // for(int i=0; i < blackPlayers.Count; i++){

        int i = 0;
        foreach(GameObject player in blackPlayers){

            startPosBlack.Add(player.transform.position);
            startRotBlack.Add(player.transform.rotation);
            Debug.Log("Start Position of" +i + player.transform.position + "is : " + startPosBlack[i]);
            i++;
        }
        startPos = chessPlayer.transform.position;
        startRot = chessPlayer.transform.rotation;
        startX = (int)chessPlayer.transform.position.x;
        startY =  (int)chessPlayer.transform.position.z;
        Vector3 distance = new Vector3(0.2f,2.0f,0.2f);
    }

    public void checkEndField(Collider figure,ChessTile incomeTile){

        ChessPlayer incomeCP = figure.GetComponent<ChessPlayer>();

        if(!solved && incomeTile == endTilePiece && incomeCP.currPlayer == cp.currPlayer && incomeCP.currPlayerColor == cp.currPlayerColor){

            Debug.Log("Position found: " + chessPlayer.transform.position );
            col.addPuzzlePiece();
            solved = true;
            dataStorage.chess = true;

            foreach(GameObject cp in blackPlayers){
                cp.GetComponent<ChessPlayer>().freezePlayer();
            }
            foreach(GameObject cp in whitePlayers){
                cp.GetComponent<ChessPlayer>().freezePlayer();
            }



        }else if(incomeCP.currPlayerColor != cp.currPlayerColor){
            Debug.Log("You ar not White!");
            Debug.Log(incomeCP.currPlayer);
            incomeCP.setBackToStart();
            //resetChess.resetChessBoard(chessPrefab);
            //OnReset();
        }else if(incomeCP.currPlayer != cp.currPlayer){
            Debug.Log("Nein versuchs nochmal");
incomeCP.setBackToStart();
            //resetChess.resetChessBoard(chessPrefab);
            //OnReset();
        }else if(incomeTile != endTilePiece){
            Debug.Log("Nein versuchs nochmal");
                                    Debug.Log(incomeCP.currPlayer);
incomeCP.setBackToStart();
            //resetChess.resetChessBoard(chessPrefab);
        }

    }




    // Update is called once per frame
    void Update()
    {
        // if(chessPlayer.transform.position.x > (startX +2) || chessPlayer.transform.position.x < (startX -2) || chessPlayer.transform.position.z > (startY +2) || chessPlayer.transform.position.z < (startY -2) ){
        //     Debug.Log("Position not legal back to origin" );
        //     chessPlayer.transform.position = startPos;
        //     chessPlayer.transform.rotation = startRot;
        // }
        // if(chessPlayer.transform.position.x >= endTile.transform.position.x - distance || chessPlayer.transform.position.x <= endTile.transform.position.x + distance && 
        //     chessPlayer.transform.position.z >= endTile.transform.position.z - distance || chessPlayer.transform.position.z <= endTile.transform.position.z + distance){
        //     Debug.Log("Position found: " + chessPlayer.transform.position );
        // }
        // if(endTile.boxcollider.trigger == true &&  ){
        //         Debug.Log("Position found: " + chessPlayer.transform.position );
        // }
        
        // int i ;
        // //foreach(GameObject player in blackPlayers){
        // for(i=0; i < blackPlayers.Count; i++){
        //     if(startPosBlack[i][0] != blackPlayers[i].transform.position.x && startPosBlack[i][2] != blackPlayers[i].transform.position.z ){
        //         Debug.Log("You ar not Black!" +i + blackPlayers[i].transform.position + "is : " + startPosBlack[i] );
        //         blackPlayers[i].transform.position = startPosBlack[i];

        //         blackPlayers[i].transform.position = startPosBlack[i];
        //         blackPlayers[i].transform.rotation = startRotBlack[i];


        //         // GameObject p = blackPlayers[i];
        //         // Destroy(p);
        //         // Instantiate(blackPlayers[i], startPosBlack[i], startRotBlack[i]);
        //         i++;

        //     }
            
        // }



        // for(int i=0; i < blackPlayers.Count; i++){
        //     if(startPosBlack.IndexOf(i) != blackPlayers.IndexOf(i).transform.position){
        //         Debug.Log("You ar not Black!");
        //         //blackPlayers[i].transform.position = startPosBlack[i];

        //     }
        // }

        // Debug.Log("Position of white prawn found: " + (int)chessPlayer.transform.position.x  + "" + (int)chessPlayer.transform.position.z );
        //         Debug.Log("Position of End Tile: " + endTile.transform.position.x  + "" + endTile.transform.position.z );
        
    }
}
