using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public Transform interactorTransform;
    public Animator animator;
    private NPCHeadLookAt npcHeadLookAt;
    public DialogManager dm;
    public string[] dialogue;

    public int dialogueIndex;

    private int currentIndex;

    private void Awake(){
        //animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
        dialogueIndex = 0;
        
    }

    private void UpdateDialogue(){
            dm.HideDialog();
            dm.beginDialogue(dialogue, dialogueIndex );
        
    }

    
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Head")){
            dm.beginDialogue(dialogue, dialogueIndex );
            currentIndex = dialogueIndex;
        }
        
    }
  


    public void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Head")){
            // change Dialogue text if index was updated while staying inside Trigger
            if(currentIndex != dialogueIndex){
                UpdateDialogue();
                currentIndex = dialogueIndex;
            }else{
                dm.ShowDialog(transform.position);
                npcHeadLookAt.LookAtPosition(interactorTransform.position);
            }
        }
    }
    
    public void OnTriggerExit (Collider other){
        if(other.gameObject.CompareTag("Head")){
        dm.HideDialog();
        npcHeadLookAt.isLookingAtPosition = false;
        }
    }
}
