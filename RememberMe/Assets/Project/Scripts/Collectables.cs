using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    List<GameObject> puzzleObjects = new List<GameObject>();
    
    private List<Vector3> puzzlePos = new List<Vector3>();
    private Vector3 puzzleRot;

    [SerializeField]
    GameObject alpacaTreat;


    [SerializeField]
    List <GameObject> chessboards;

    public bool treatCollected;
    public bool alpacaIgnorePlayer;

    [SerializeField]
    NPCInteractable pablo;

    [SerializeField]
    public Data_Storage data_Storage;
    [SerializeField]
    public GameObject time;
    [SerializeField]
    public Text timeText;

    ArrayList puzzleparts = new ArrayList();
    int countPiece;

    private AudioSource audio;


    [SerializeField]
    NPCInteractable cristobal;

    [SerializeField]
    NPCInteractable don;

    public AudioClip[] voiceLine;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        addPuzzlePosAndRot();

        audio = GetComponent<AudioSource>();

        
        switch (data_Storage.level){
            case 1:
                Instantiate(chessboards[0], new Vector3(-25.47f, -0.83f, 11.28976f), Quaternion.identity);
                break;
            case 2:
                Instantiate(chessboards[1], new Vector3(-25.47f, -0.83f, 11.28976f), Quaternion.identity);
                break;
            case 3:
                Instantiate(chessboards[2], new Vector3(-25.47f, -0.83f, 11.28976f), Quaternion.identity);
                break;
            default:
                break;
        }
        
        countPiece = 0;
        treatCollected = false;
        alpacaIgnorePlayer = false;
        if(data_Storage.alpaca){
            alpacaIgnorePlayer = true;
        }  
        Invoke ("updatePhoto", 1);

        // AudioSource-Komponente abrufen oder hinzufügen
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Voice Line zuweisen
        audioSource.clip = voiceLine[0];
        audioSource.maxDistance = 2;
        audioSource.spatialBlend = 1;

    }

    private void updatePhoto(){
        for(int i = 0; i <data_Storage.puzzlesSolved ; i++){
            //Instantiate(puzzleObjects[countPiece], puzzlePos[countPiece], Quaternion.Euler(puzzleRot));
            puzzleObjects[countPiece].GetComponent<HideObject>().makeVisible();
            countPiece ++;
            pablo.dialogueIndex ++;
            timeText.text = countPiece.ToString();
        }  
        if(data_Storage.mazeWon){
            cristobal.dialogueIndex ++;
        }
        if(data_Storage.shootingRangeWon){
            don.dialogueIndex ++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update the remaining time in Data Storage scriptable Object
        if(data_Storage != null){
            data_Storage.time = time.GetComponent<Timer>().timeRemaining;
        }
        
    }


    public void addPuzzlePiece(){
            
        puzzleObjects[countPiece].GetComponent<HideObject>().makeVisible();
        //Instantiate(puzzleObjects[countPiece], puzzlePos[countPiece], Quaternion.Euler(puzzleRot));
        countPiece ++;
        data_Storage.puzzlesSolved ++;
        pablo.dialogueIndex ++;

        audioSource.clip = voiceLine[0];
        //audio.Play();
        audioSource.Play();

        timeText.text = countPiece.ToString();

        if(data_Storage.level == 1 && data_Storage.puzzlesSolved == 5){
            // play audio 
            //"Super du hast die benoetigte Anzahl an Phototeilen gefunden, wenn du fruehzeitig aufhoeren willst geh zu Pablo. Du kannst aber natuerlich auch noch die zwei uebrigen finden Muchacho."
            audioSource.clip = voiceLine[1];
            audioSource.Play();
            audioSource.clip = voiceLine[0];

        } else if(data_Storage.puzzlesSolved == 7){
            // play audio
            //"Bravo du hast alle Teile des Photos gefunden geh zurueck zu Pablo und die Party kann beginnen."

            audioSource.clip = voiceLine[2];
            audioSource.Play();

            time.GetComponent<Timer>().stopTimer();
        }

    }

    public void collectTreat(){
        treatCollected = true;
        //audio.Play();
        audioSource.Play();
        
    }

    private void addPuzzlePosAndRot(){
        puzzleRot = new Vector3(0f,90f,270f);
        puzzlePos.Add(new Vector3(7.4f,2f,17.3883f));
        puzzlePos.Add(new Vector3(7.9f,2f,17.3883f));
        puzzlePos.Add(new Vector3(8.4f,2f,17.3883f));
        puzzlePos.Add(new Vector3(7.4f,1.5f,17.3883f));
        puzzlePos.Add(new Vector3(7.9f,1.5f,17.3883f));
        puzzlePos.Add(new Vector3(8.4f,1.5f,17.3883f));
        puzzlePos.Add(new Vector3(7.9f,1.1f,17.3883f));
    }
}


