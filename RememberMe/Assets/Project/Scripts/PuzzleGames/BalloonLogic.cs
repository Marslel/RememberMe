using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonLogic : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Balloon Animation")]
    Animation ani;
    [SerializeField]
    [Tooltip("Position of the Balloon")]
    Transform pos;

    [SerializeField]
    [Tooltip("Collectables Script that stores puzzle pieces")]
    Collectables col;
    [SerializeField]
    [Tooltip("Item that needs to enter the Collider")]
    GameObject  neededItem;
    [SerializeField]
    [Tooltip("Campfire that needs to be hidden")]
    GameObject objectToHide;

    Vector3 startPos;

    [SerializeField]
    Data_Storage dataStorage;

    bool puzzleCompleted;


    // Start is called before the first frame update
    void Start()
    {
        startPos = pos.position;
        puzzleCompleted = dataStorage.balloon;
        if(puzzleCompleted){
            neededItem.GetComponent<HideObject>().makeInvisible();
            objectToHide.GetComponent<HideObject>().chooseVisibleInGame = true;
            ani.Play("airballoon");
            objectToHide.GetComponent<HideObject>().makeVisible();

         
        }
    }

    /// <summary>
    /// completes the puzzle by changing the visibillity of the itm to find, playing the ballon starting animation and adding a piece of the puzzle to the game
    /// </summary>
    /// <param name="other"> The collider that enters the Trigger Collider</param>
    private void OnTriggerEnter(Collider other){
        if(!puzzleCompleted && other == neededItem.GetComponent<Collider>()){
            
            // swap visibillity of the fire
            neededItem.GetComponent<HideObject>().makeInvisible();
            objectToHide.GetComponent<HideObject>().makeVisible();

            ani.Play("airballoon");
            col.addPuzzlePiece();
            puzzleCompleted = true;
            dataStorage.balloon = true;

        }
    }

    /// <summary>
    /// set the position of the Balloon to the sky
    /// </summary>
    public void setBaloonPosition(){
        pos.position = (startPos + new Vector3(-198.2f,150.3f,134.6f));
    }

}
