using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject containerGameObject;
    public Transform playerInteract;
    public PanelDialogue pd;

     public void Start(){

        containerGameObject.SetActive(false);

     }
    public void ShowDialog( Vector3 npcPosition)
    {
        

        // Position des Dialogfensters relativ zur Position des NPCs
        Vector3 dialogPosition = npcPosition + new Vector3(0f, 2.5f, 0f);

        // Setze die Position des Dialogfensters
        transform.position = dialogPosition;


        transform.LookAt(playerInteract);
        
    }
    public void beginDialogue(string[] dialogue){
        containerGameObject.SetActive(true);
        pd.textComponent.text = string.Empty;
        pd.dialogueLines = dialogue;
        pd.startDialogue();

    }

    public void HideDialog()
    {
        containerGameObject.SetActive(false);
    }

    
    

}
