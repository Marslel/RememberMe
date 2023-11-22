using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSequence : MonoBehaviour
{
    public static int TIME = 5000;

    [HideInInspector]
    public GameObject currentKey;

    GameObject lastKey;

    public bool? rightKey = null;
    public bool IsSequenceGoing = false;
    System.DateTime timer;
    bool IsPlayerTrying = false;
    bool modifiable = true;

    void Update()
    {
        if (IsSequenceGoing)
        {
            if (IsPlayerTrying)
            {
                ChangeColor(currentKey, Color.blue);

                if(System.DateTime.Now < timer.AddMilliseconds(TIME))
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
                if ( System.DateTime.Now > timer.AddMilliseconds(TIME))
                { 
                    ChangeColor(currentKey, Color.white);
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


    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        currentKey = GetRandomKey();

        timer = System.DateTime.Now;
        IsSequenceGoing = true;
        IsPlayerTrying = true;
        rightKey = null;
    }

    GameObject GetRandomKey()
    {
        // Finde das andere Objekt mit dem Namen "AnderesObjekt"
        int id = new System.Random().Next(1, 53);
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
