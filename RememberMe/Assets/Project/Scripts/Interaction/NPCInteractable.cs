using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public Transform interactorTransform;
    private Animator animator;
    private NPCHeadLookAt npcHeadLookAt;
    public DialogManager dm;
    public string[] dialogue;

    private void Awake(){
        animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
        
    }

    public void Interact(){
        
    }

    
    public void OnTriggerEnter(Collider other){
        dm.beginDialogue(dialogue);
    }


    public void OnTriggerStay(Collider other){
        dm.ShowDialog(transform.position);
        npcHeadLookAt.LookAtPosition(interactorTransform.position);

    }
    
    public void OnTriggerExit (Collider other){
        Debug.Log("Object left");
        dm.HideDialog();
        npcHeadLookAt.isLookingAtPosition = false;
    }
}
