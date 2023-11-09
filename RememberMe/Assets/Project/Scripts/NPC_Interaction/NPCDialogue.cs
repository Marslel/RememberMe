using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueCanvas;

    private void Start()
    {
        dialogueCanvas.SetActive(false);
    }

    public void StartDialogue()
    {
        dialogueCanvas.SetActive(true);
        // Hier weitere Dialoglogik implementieren
    }
}
