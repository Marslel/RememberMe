using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSequence : MonoBehaviour
{
	public AudioClip[] saw;    // Add your Audi Clip Here;

    public int SHOWTIME = 5000;

    [HideInInspector]
    public GameObject currentKey;

    [Min (1)]
    public int numberOfKeys = 5;

    [Range (0, 26)]
    public int keyRange = 15;

    [Min (1)]
    public int inputTime = 10000;

    GameObject lastKey;

    public bool? rightKey = null;
    public bool IsSequenceGoing = false;
    System.DateTime timer;
    bool IsPlayerTrying = false;
    bool modifiable = true;
    int keyCount = 0;

    [SerializeField]
    private Data_Storage data;
    [SerializeField]
    private Collectables collectables;
    private bool explanationNeeded = true;

    public GameObject dialog;

    private bool dummyTimeFail = false;

    void Start ()   
	{
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = saw[0];
    }    	

    void Update()
    {
        
        if (IsSequenceGoing && !data.pianoWon)
        {
            if(explanationNeeded)
            {
                if(System.DateTime.Now > timer.AddMilliseconds(20000))
                {
                    explanationNeeded = false;
                    timer = System.DateTime.Now;
                }
            }
            else if (IsPlayerTrying)
            {

                if(System.DateTime.Now < timer.AddMilliseconds(inputTime))
                {
                    if(rightKey.HasValue)
                    {
                        IsPlayerTrying = false;
                        return;
                    }
                }
                else
                {
                    dummyTimeFail = true;
                    rightKey = false;
                    IsPlayerTrying = false;
                    for (int i = 1; i < 53; i++)
                    {
                        ChangeColor(GameObject.Find("props_148key" + i.ToString()), Color.red);
                    }
                    timer = System.DateTime.Now;
                    return;
                }
                ChangeColor(currentKey, Color.blue);
            }
            else
            {
                if ( System.DateTime.Now > timer.AddMilliseconds(SHOWTIME))
                {
                    keyCount++;
                    if(keyCount == numberOfKeys && rightKey.Value == true)
                    {
                        for (int i = 1; i < 53; i++)
                        {
                            ChangeColor(GameObject.Find("props_148key" + i.ToString()), Color.green);
                            timer = System.DateTime.Now;
                        }
                        dialog.GetComponent<PianoNPCInteractable>().dialogueIndex++;
                    }
                    else if(keyCount >= numberOfKeys && rightKey.Value == true)
                    {
                        for (int i = 1; i < 53; i++)
                        {
                            ChangeColor(GameObject.Find("props_148key" + i.ToString()), Color.white);

                        }
                        data.pianoWon = true;
                        collectables.addPuzzlePiece();
                        IsSequenceGoing = false;
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        for(int i = 1; i < 53; i++)
                        {
                            ChangeColor(GameObject.Find("props_148key" + i.ToString()), Color.white);
                        }
                        if (rightKey.Value)
                        {
                            currentKey = GetRandomKey();
                            IsPlayerTrying = true;
                            rightKey = null;
                            timer = System.DateTime.Now;
                            modifiable = true;
                        }
                        else
                        {
                            IsSequenceGoing = false;
                            if(dummyTimeFail){
                                data.PianoFailedDueTime++;
		                        GetComponent<AudioSource> ().clip = saw[1];
                            } else {
                                data.PianoFailedDueError++;
		                        GetComponent<AudioSource> ().clip = saw[2];
                            }
                            GetComponent<AudioSource> ().Play();
                            dummyTimeFail = false;
                        }
                    }
                }
            }
        }
    }
    public Vector3 vec1;
    public Vector3 vec2;

    UnityEngine.Vector3 teleportPosition;

    void OnCollisionEnter()  
    {
        if(data.pianoWon)
        {
            return;
        }
        Debug.Log("Collision");
        

        if(data.level == 1){
            SHOWTIME = 5000;
            inputTime = 10000;
            keyRange = 8;
            numberOfKeys = 5; 
        } else if (data.level == 2){
            SHOWTIME = 3000;
            inputTime = 7000;
            keyRange = 15;
            numberOfKeys = 15;
        } else {
            SHOWTIME = 3000;
            inputTime = 5000;
            keyRange = 26;
            numberOfKeys = 20;
        }
        
        currentKey = GetRandomKey();

        timer = System.DateTime.Now;
        IsSequenceGoing = true;
        IsPlayerTrying = true;
        rightKey = null;
        keyCount = 0;
        dummyTimeFail = false;

        GameObject position = GameObject.Find("Teleport_Position_Piano");
        GameObject player = null;// GameObject.FindGameObjectWithTag("test");
        if(player != null)
        {
            Debug.Log(player.name);
            position = GameObject.Find("Teleport_Position_Piano");
            player = GameObject.FindGameObjectWithTag("test");
            player.transform.position = new Vector3(position.transform.position.x, position.transform.position.y, position.transform.position.z);
            
            //player.transform.position = new Vector3(0, 1, 6);
            GameObject camHolder = GameObject.Find("CameraHolder"); 
            camHolder.transform.position =  new Vector3(position.transform.position.x, position.transform.position.y - 1, position.transform.position.z - 6);
            if(explanationNeeded){
                GetComponent<AudioSource>().Play();
            }
        }else{
            Debug.Log("in VR Teleport");
            data.pianoTries++;

            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(position.transform.position.x, position.transform.position.y, position.transform.position.z);
            GameObject perspective = GameObject.Find("FallbackObjects");
            if(explanationNeeded){
                GetComponent<AudioSource>().Play();
            }
            perspective.transform.eulerAngles = new Vector3(45, 142, 0);
        }
    }

    GameObject GetRandomKey()
    {
        // Finde das andere Objekt mit dem Namen "AnderesObjekt"
        int id = new System.Random().Next(27 - keyRange, 27 + keyRange);
        while (id % 2 != 0){
            id = new System.Random().Next(27 - keyRange, 27 + keyRange); 
        }
        return GameObject.Find("props_148key" + id.ToString());
    }

    void ChangeColor(GameObject gameObject, Color color)
    {
        // Versuche, den Renderer des letzten Objekts zu erhalten
        Renderer lastObjectRenderer = gameObject.GetComponent<Renderer>();

        // �berpr�fe, ob ein Renderer vorhanden ist
        if (lastObjectRenderer != null)
        {
            // �ndere das Material des gefundenen Objekts
            lastObjectRenderer.material.color = color;
        }
        else
        {
            Debug.LogError("Das gefundene Objekt hat keinen Renderer.");
        }
    }
}
