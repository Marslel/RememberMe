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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other){

        if(other.tag == "Player"){

            if(data_Storage != null){
                data_Storage.updateMazeWon(true);
                data_Storage.updatePuzzlesSolved(1);
                data_Storage.adaptTimer(time.GetComponent<Timer>().timeRemaining);
            }
            exit.GetComponent<HideObject>().makeVisible();
        }  
    }

}
