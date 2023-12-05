using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpacaPuzzleLogic : MonoBehaviour
{
    [SerializeField]
    GameObject alpacaHat;
    [SerializeField]
    HideObject alHat;

    [SerializeField]
    GameObject skellyHat;

    [SerializeField]
    GameObject tempHat;

    [SerializeField]
    Collectables col;

    [SerializeField]
    Animator anim;

    [SerializeField]
    Data_Storage dataStorage;

    bool puzzleCompleted;

    // Start is called before the first frame update
    void Start()
    {
        puzzleCompleted = dataStorage.alpaca;
        if(puzzleCompleted){
            
            alHat.chooseVisibleInGame = true;
            updateAlpacaPuzzle();

        }
    }

    private void OnTriggerEnter(Collider other){
        if(!puzzleCompleted && other == alpacaHat.GetComponent<Collider>()){
            alpacaHat.GetComponent<HideObject>().makeInvisible();
            //tempHat.GetComponent<HideObject>().makeVisible();
            anim.Play("Base Layer.transformhat");



        }
    }

public void updateAlpacaPuzzle(){
    //tempHat.GetComponent<HideObject>().makeInvisible();
    anim.Play("Base Layer.invisiblehat");
    skellyHat.GetComponent<HideObject>().makeVisible();
    Debug.Log("You found my Hat thank you!");
    
    tempHat.GetComponent<HideObject>().makeInvisible();
    col.addPuzzlePiece();
    puzzleCompleted = true;
    dataStorage.alpaca = true;
    col.alpacaIgnorePlayer = true;
    alpacaHat.GetComponent<HideObject>().makeInvisible();

}


}
