using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Update_Maze_Status : MonoBehaviour
{
    [SerializeField]
    public Data_Storage data_Storage;
    [SerializeField]
    public GameObject exit;
    [SerializeField]
    public GameObject time;
    private bool alreadyUpdated;

    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.FindGameObjectWithTag("House");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other){

        if(other.tag == "Head"){

            if(data_Storage != null && alreadyUpdated != true){
                data_Storage.updateMazeWon(true);
                data_Storage.updatePuzzlesSolved(1);
                data_Storage.mazeRemainedTime = time.GetComponent<Timer>().timeRemaining;
                data_Storage.adaptTimer(data_Storage.mazetime - time.GetComponent<Timer>().timeRemaining);
                alreadyUpdated = true;
            }
            exit.GetComponent<HideObject>().makeVisible();
        }  
    }

}
