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

    private void Awake(){
        //animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
        dialogueIndex = 0;
        
    }

    public void Interact(){
        
    }

    
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Head")){
            //dm.beginDialogue(dialogue);
            dm.beginDialogue(dialogue, dialogueIndex );
        }
        
    }
  


    public void OnTriggerStay(Collider other){
        dm.ShowDialog(transform.position);
        npcHeadLookAt.LookAtPosition(interactorTransform.position);

    }
    
    public void OnTriggerExit (Collider other){
        
        dm.HideDialog();
        npcHeadLookAt.isLookingAtPosition = false;
    }
}
