using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoNPCInteractable : MonoBehaviour
{
    public Transform interactorTransform;
    public Animator animator;
    private NPCHeadLookAt npcHeadLookAt;
    public DialogManager dm;
    public string[] dialogue;

    public int dialogueIndex;

    public int test;

    private System.DateTime timer = System.DateTime.Now.AddDays(10);

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
            timer = System.DateTime.Now;
            HideNote();
        }
        
    }
  


    public void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("Head")){
            dm.ShowDialog(transform.position);
            npcHeadLookAt.LookAtPosition(interactorTransform.position);
                if(System.DateTime.Now > timer.AddMilliseconds(test)){
                    ShowNote();
                    timer = System.DateTime.Now.AddDays(10);
                }
        }
    }
    
    public void OnTriggerExit (Collider other){
        if(other.gameObject.CompareTag("Head")){
        dm.HideDialog();
        npcHeadLookAt.isLookingAtPosition = false;
        }
    }

    private void ShowNote(){
        transform.parent.parent.parent.Find("eighth_note").gameObject.SetActive(true);
    }

    private void HideNote(){
        transform.parent.parent.parent.Find("eighth_note").gameObject.SetActive(false);
    }
}
