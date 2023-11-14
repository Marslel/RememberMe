using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessLogic : MonoBehaviour
{
    [SerializeField]
    GameObject chessPlayer;
    ChessPlayer cp;

    [SerializeField] 
    GameObject endTile; 
    
    [SerializeField]
    List<GameObject> whitePlayers = new List<GameObject>();
    
    [SerializeField]
    List<GameObject> blackPlayers = new List<GameObject>();
    

    List<Vector3> startPosBlack;
    List<Quaternion> startRotBlack;
    
    int startX;
    int startY;
    float distance;
    Vector3 startPos;
    Quaternion startRot;

    ChessTile endTilePiece;

    // Start is called before the first frame update
    void Start()
    {

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

        if(incomeTile == endTilePiece && incomeCP.currPlayer == cp.currPlayer && incomeCP.currPlayerColor == cp.currPlayerColor){

            Debug.Log("Position found: " + chessPlayer.transform.position );
        }else if(incomeTile == endTilePiece && incomeCP.currPlayerColor != cp.currPlayerColor){
            Debug.Log("You ar not Black!");
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(chessPlayer.transform.position.x > (startX +2) || chessPlayer.transform.position.x < (startX -2) || chessPlayer.transform.position.z > (startY +2) || chessPlayer.transform.position.z < (startY -2) ){
            Debug.Log("Position not legal back to origin" );
            chessPlayer.transform.position = startPos;
            chessPlayer.transform.rotation = startRot;
        }
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
