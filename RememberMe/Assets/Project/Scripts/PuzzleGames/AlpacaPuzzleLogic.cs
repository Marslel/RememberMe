using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlpacaPuzzleLogic : MonoBehaviour
{
    [SerializeField]
    GameObject alpacaHat;

    [SerializeField]
    GameObject skellyHat;

    [SerializeField]
    GameObject tempHat;

    [SerializeField]
    Collectables col;

    [SerializeField]
    Animator anim;

    bool puzzleCompleted;

    // Start is called before the first frame update
    void Start()
    {
        puzzleCompleted = false;
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
    col.alpacaIgnorePlayer = true;
}


}
