using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Button yesButton;
    public Button noButton;
    public GameObject containerGameObject;
    public Non_VR_Player_Interact playerInteract;
    

     void Start()
    {
        // Deaktiviere die Buttons zu Beginn
        yesButton.interactable = false;
        noButton.interactable = false;
        // Beispielhaft: Trigger das Event nach einer Verzögerung
        Invoke("EnableButtons", 3f);
    }

    void Update(){
        if(playerInteract.GetInteractableObject() != null){
            ShowDialog(playerInteract.GetInteractableObject().transform.position);
        }
        else{
            HideDialog();
        }
        }


    
    public void ShowDialog( Vector3 npcPosition)
    {
        //dialogText.text = text;

        // Position des Dialogfensters relativ zur Position des NPCs
        Vector3 dialogPosition = npcPosition + new Vector3(0f, 2.5f, 0f);

        // Setze die Position des Dialogfensters
        transform.position = dialogPosition;

        containerGameObject.SetActive(true);
    }

    public void HideDialog()
    {
        containerGameObject.SetActive(false);
    }

    void EnableButtons()
    {
        // Aktiviere die Buttons, wenn der Text fertig ist
        yesButton.interactable = true;
        noButton.interactable = true;
    }

    // Funktionen für Button-Klicks
    public void OnYesButtonClick()
    {
        Debug.Log("Ja ausgewählt");
        // Füge hier die Aktion für "Ja" hinzu
    }

    public void OnNoButtonClick()
    {
        Debug.Log("Nein ausgewählt");
        // Füge hier die Aktion für "Nein" hinzu
    }

}
