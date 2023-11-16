using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public GameObject containerGameObject;
    public Non_VR_Player_Interact playerInteract;
    


 /* void Update(){
        if(playerInteract.GetInteractableObject() != null){
            ShowDialog(playerInteract.GetInteractableObject().transform.position);
        }
        else{
            HideDialog();
        }
        }

*/
     public void Start(){

        containerGameObject.SetActive(false);

     }
    public void ShowDialog( Vector3 npcPosition)
    {
        //dialogText.text = text;

        // Position des Dialogfensters relativ zur Position des NPCs
        Vector3 dialogPosition = npcPosition + new Vector3(0f, 2.5f, 0f);

        // Setze die Position des Dialogfensters
        transform.position = dialogPosition;
        transform.LookAt(playerInteract.transform);
        containerGameObject.SetActive(true);
    }

    public void HideDialog()
    {
        containerGameObject.SetActive(false);
    }

    
    

}
