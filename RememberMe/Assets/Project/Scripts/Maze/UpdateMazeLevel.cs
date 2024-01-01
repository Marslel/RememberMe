using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMazeLevel : MonoBehaviour
{
    [SerializeField]
    public Data_Storage data_Storage;
    public List<GameObject> MazePrefabs;

    [SerializeField]
    public NPCInteractable npc;

    [SerializeField]
    public Text timeText;
    int countPiece;
    // Start is called before the first frame update
    void Start()
    {
        if(data_Storage.level == 1){
            
            Instantiate(MazePrefabs[0], new Vector3(-39.52f, 0.0f, 16.55f), Quaternion.identity);
            npc.dialogueIndex = 1;
            
        }else if(data_Storage.level == 2 ){
            Instantiate(MazePrefabs[1], new Vector3(-51.01407f, -4.77844f, -5.782525f), Quaternion.identity);
            npc.dialogueIndex = 0;
        }else if(data_Storage.level == 3){
            Instantiate(MazePrefabs[1], new Vector3(-51.01407f, -4.77844f, -5.782525f), Quaternion.identity);
            npc.dialogueIndex = 0;
        }

        // adapt puzzles solved on ui
        countPiece = data_Storage.puzzlesSolved;
        Debug.Log("Puzzles solved :" +countPiece);
        timeText.text = countPiece.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
