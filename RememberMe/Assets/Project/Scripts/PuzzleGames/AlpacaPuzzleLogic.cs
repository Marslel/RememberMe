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
    Collectables col;

    bool puzzleCompleted;

    // Start is called before the first frame update
    void Start()
    {
        puzzleCompleted = false;
    }

    private void OnTriggerEnter(Collider other){
        if(other == alpacaHat.GetComponent<Collider>() && !puzzleCompleted){
            alpacaHat.GetComponent<HideObject>().makeInvisible();
            skellyHat.GetComponent<HideObject>().makeVisible();
            Debug.Log("You found my Hat thank you!");
            col.addPuzzlePiece();
            puzzleCompleted = true;
            col.alpacaIgnorePlayer = true;

        }
    }

}
