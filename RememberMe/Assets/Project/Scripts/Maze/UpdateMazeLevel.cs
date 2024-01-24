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
    [SerializeField]
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        if(data_Storage.level == 1){
            
            Instantiate(MazePrefabs[0], new Vector3(-39.52f, 0.0f, 16.55f), Quaternion.identity);
            npc.dialogueIndex = 1;
            //map.enabled = false;
            map.SetActive(false);
        }else if(data_Storage.level == 2 ){
            Instantiate(MazePrefabs[1], new Vector3(-51.01407f, -4.77844f, -5.782525f), Quaternion.identity);
            npc.dialogueIndex = 2;
        }else if(data_Storage.level == 3){
            Instantiate(MazePrefabs[1], new Vector3(-51.01407f, -4.77844f, -5.782525f), Quaternion.identity);
            npc.dialogueIndex = 0;
        }

        // adapt puzzles solved on ui
        countPiece = data_Storage.puzzlesSolved;
        Debug.Log("Puzzles solved :" +countPiece);
        timeText.text = countPiece.ToString();
        data_Storage.mazeTries += 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
