using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlayer : MonoBehaviour
{

    [SerializeField]
    public playertype currPlayer;
    [SerializeField]
    public playercolor currPlayerColor;


    Vector3 startPos;
    Quaternion startRot;
    public enum playertype{
        tower1,
        horse1,
        bishop1,
        king,
        queen,
        bishop2,
        horse2,
        tower2,
        pawn1,
        pawn2,
        pawn3,
        pawn4,
        pawn5,
        pawn6,
        pawn7,
        pawn8
    }

    public enum playercolor{
        white,
        black
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void setBackToStart()
    {        
        transform.position = startPos;
        transform.rotation = startRot;
        //transform.scale = startPos.scale;

    }

    public void freezePlayer(){
        //GetComponent<Throwable>().enabled = false;
        //this.AddComponent<IgnoreHovering>();
        // GetComponent<Rigidbody>().velocity = Vector3.zero;
        // GetComponent<Interactable>().enabled = false;
        
    }

}
