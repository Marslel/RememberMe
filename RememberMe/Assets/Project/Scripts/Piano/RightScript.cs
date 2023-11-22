using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Versuche, den Renderer des letzten Objekts zu erhalten
        Renderer lastObjectRenderer = gameObject.GetComponent<Renderer>();

        // Überprüfe, ob ein Renderer vorhanden ist
        if (lastObjectRenderer != null)
        {
            // Ändere das Material des gefundenen Objekts
            lastObjectRenderer.material.color = Color.green;
        }
        else
        {
            Debug.LogError("Das gefundene Objekt hat keinen Renderer.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        GameObject pianoObject = GameObject.Find("Piano_Cube"); // Hier den richtigen Namen des GameObjects einsetzen
        ShowSequence showSequenceScript = pianoObject.GetComponent<ShowSequence>();
        
        showSequenceScript.rightKey = true;
    }
}
