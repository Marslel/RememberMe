using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAtRuntime : MonoBehaviour
{
    public Transform interactorTransform;
    private NPCHeadLookAt npcHeadLookAt;
    public DialogManager dm;
    public string[] dialogue;

    public int dialogueIndex;

    private void Awake(){

        interactorTransform = GameObject.FindGameObjectWithTag("Head").GetComponent<Transform>();
        dm = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogManager>();


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
        if(other.gameObject.CompareTag("Head")){
        dm.ShowDialog(transform.position);
        npcHeadLookAt.LookAtPosition(interactorTransform.position);
        }
    }
    
    public void OnTriggerExit (Collider other){
        if(other.gameObject.CompareTag("Head")){
        dm.HideDialog();
        npcHeadLookAt.isLookingAtPosition = false;
        }
    }
}
