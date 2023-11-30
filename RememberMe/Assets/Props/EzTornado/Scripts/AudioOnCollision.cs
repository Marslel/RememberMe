using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

//Add this Script Directly to The Death Zone
public class AudioOnCollision : MonoBehaviour
{
	public AudioClip saw;    // Add your Audi Clip Here;

    public bool chosen;
    public int timer;
    private GameObject eighthNotePrefab; // Das Prefab, das du in der Unity-Editor-Oberfläche zuweisen musst.

    // This Will Configure the  AudioSource Component; 
    // MAke Sure You added AudioSouce to death Zone;
    void Start ()   
	{
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = saw;

        eighthNotePrefab = Resources.Load<GameObject>("theNotes/Model/Prefab/Note/eighth_note_dotted");
    }    	

	void OnCollisionEnter ()  //Plays Sound Whenever collision detected
	{
		GameObject pianoObject = GameObject.Find("Piano_Cube"); // Hier den richtigen Namen des GameObjects einsetzen
		ShowSequence showSequenceScript = pianoObject.GetComponent<ShowSequence>();
        if (showSequenceScript.IsSequenceGoing)
        {
            if (showSequenceScript.currentKey == gameObject)
            {
                GetComponent<AudioSource>().Play();
                showSequenceScript.rightKey = true;
                ChangeColor(gameObject, Color.green);
                GameObject note = SpawnEighthNote();
                FindChild findChildScript = note.GetComponent<FindChild>();

                ChangeColor(findChildScript.FindNoteBody(), Color.green);
                //Transform childTransform = transform.Find("eighthNotePrefab_note");
                //GameObject childObject = childTransform.gameObject;
                //ChangeColor(childObject, Color.green);
            }
            else
            {
                GetComponent<AudioSource>().Play();
                showSequenceScript.rightKey = false;
                ChangeColor(gameObject, Color.red);
                GameObject note = SpawnEighthNote();
                FindChild findChildScript = note.GetComponent<FindChild>();

                ChangeColor(findChildScript.FindNoteBody(), Color.red);
            }
        }
        else
        {
            GetComponent<AudioSource>().Play();
        }
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

    GameObject SpawnEighthNote()
    {
        // Prüfe, ob das Prefab zugewiesen wurde.
        if (eighthNotePrefab != null)
        {
            // Erzeuge eine Instanz des Prefabs an der aktuellen Position des GameObjects, zu dem dieses Skript gehört.
            return Instantiate(eighthNotePrefab, transform.position, Quaternion.identity);
            Debug.Log(transform.position);

            // Hier könntest du zusätzliche Aktionen für die neue Instanz durchführen, falls erforderlich.
        }
        else
        {
            Debug.Log("Prefab für die Achtelnote nicht zugewiesen!");
            return null;
        }
    }
}
