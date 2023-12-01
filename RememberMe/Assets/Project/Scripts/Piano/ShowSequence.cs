using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSequence : MonoBehaviour
{
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

    public GameObject player;
    public GameObject bench;
    public GameObject cameraHolder;

    public bool? rightKey = null;
    public bool IsSequenceGoing = false;
    System.DateTime timer;
    bool IsPlayerTrying = false;
    bool modifiable = true;
    int keyCount = 0;

    void Update()
    {
        if (IsSequenceGoing)
        {
            if (IsPlayerTrying)
            {
                ChangeColor(currentKey, Color.blue);

                if(System.DateTime.Now < timer.AddMilliseconds(inputTime))
                {
                    if(rightKey.HasValue)
                    {
                        IsPlayerTrying = false;
                    }
                }
                else
                {
                    rightKey = false;
                    IsPlayerTrying = false;
                    for (int i = 1; i < 53; i++)
                    {
                        ChangeColor(GameObject.Find("props_148key" + i.ToString()), Color.red);
                    }
                    timer = System.DateTime.Now;
                }
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
                    }
                    else if(keyCount >= numberOfKeys && rightKey.Value == true)
                    {
                        for (int i = 1; i < 53; i++)
                        {
                            ChangeColor(GameObject.Find("props_148key" + i.ToString()), Color.white);
                        }
                        IsSequenceGoing = false;
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
                        }
                    }
                }
            }
        }
    }
    public Vector3 vec1;
    public Vector3 vec2;

    UnityEngine.Vector3 teleportPosition;

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        currentKey = GetRandomKey();

        timer = System.DateTime.Now;
        IsSequenceGoing = true;
        IsPlayerTrying = true;
        rightKey = null;
        keyCount = 0;


            player = GameObject.FindGameObjectWithTag("Player");
            UnityEngine.Vector3 currPos = player.transform.position;
            teleportPosition = new UnityEngine.Vector3(currPos.x ,currPos.y - 6, currPos.z);
            player.transform.position = cameraHolder.transform.position;
        //vec1 = new Vector3(0.0f, 1.02f, 16.2f);
        //player.transform.position = vec1;
        //vec2 = new Vector3(0.0f, 0.0f, 0.0f);
        //cameraHolder.transform.position = vec2;
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
