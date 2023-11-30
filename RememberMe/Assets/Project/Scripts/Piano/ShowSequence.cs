using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSequence : MonoBehaviour
{
    private static int SHOWTIME = 5000;

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
                    IsSequenceGoing = false;
                }
            }
            else
            {
                if ( System.DateTime.Now > timer.AddMilliseconds(SHOWTIME))
                {
                    keyCount++;
                    if(keyCount == numberOfKeys)
                    {
                        for (int i = 1; i < 53; i++)
                        {
                            ChangeColor(GameObject.Find("props_148key" + i.ToString()), Color.green);
                            timer = System.DateTime.Now;
                        }
                    }
                    else if(keyCount >= numberOfKeys)
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


    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        currentKey = GetRandomKey();

        timer = System.DateTime.Now;
        IsSequenceGoing = true;
        IsPlayerTrying = true;
        rightKey = null;
        keyCount = 0;
    }

    GameObject GetRandomKey()
    {
        // Finde das andere Objekt mit dem Namen "AnderesObjekt"
        int id = new System.Random().Next(27 - keyRange, 27 + keyRange);
        return GameObject.Find("props_148key" + id.ToString());
    }

    void ChangeColor(GameObject gameObject, Color color)
    {
        // Versuche, den Renderer des letzten Objekts zu erhalten
        Renderer lastObjectRenderer = gameObject.GetComponent<Renderer>();

        // Überprüfe, ob ein Renderer vorhanden ist
        if (lastObjectRenderer != null)
        {
            // Ändere das Material des gefundenen Objekts
            lastObjectRenderer.material.color = color;
        }
        else
        {
            Debug.LogError("Das gefundene Objekt hat keinen Renderer.");
        }
    }
}
