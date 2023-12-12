using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetChessBoard : MonoBehaviour
{

    [SerializeField]
    GameObject chessPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetChessBoard(GameObject currentBoard){

       
        //var gObjects = currentBoard.GetComponentsInChildren<GameObject>();
        
        // for (var i = currentBoard.transform.childCount - 1; i >= 0; i--)
        // {
        //     Object.Destroy(currentBoard.transform.GetChild(i).gameObject);
        // }
        // Destroy(currentBoard);
        // var resetGameobject = GameObject.Instantiate(chessPrefab);
    }
}
