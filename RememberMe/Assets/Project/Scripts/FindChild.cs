using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public GameObject FindNoteBody()
    {
        // Ermittle ein Untergameobject mit dem Namen "ChildObjectName".
        Transform childTransform = transform.Find("eighth_note_h");

        // Überprüfe, ob das Untergameobject gefunden wurde.
        if (childTransform != null)
        {
            // Hier kannst du auf das Untergameobject zugreifen.
            return childTransform.gameObject;
        }
        else
        {
            Debug.LogError("Untergameobject nicht gefunden!");
            return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
