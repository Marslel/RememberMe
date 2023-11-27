using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    List<GameObject> puzzleObjects = new List<GameObject>();
    [SerializeField]
    public Data_Storage data_Storage;
    [SerializeField]
    public GameObject time;

    ArrayList puzzleparts = new ArrayList();
    int countPiece;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        countPiece = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(data_Storage != null){
            data_Storage.time = time.GetComponent<Timer>().timeRemaining;
        }
        
    }


    public void addPuzzlePiece(){
        Debug.Log("You found a puzzle part");

        Instantiate(puzzleObjects[countPiece], new Vector3(3, 10, 8), Quaternion.identity);
        countPiece ++;
    }
}


