using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public Transform interactorTransform;
    private Animator animator;
    private NPCHeadLookAt npcHeadLookAt;
    public DialogManager dm;

    private void Awake(){
        animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
        
    }

    public void Interact(){
        
    }

    public void OnTriggerEnter(Collider other){
        Debug.Log("Object entered");
        dm.ShowDialog(transform.position);
        npcHeadLookAt.LookAtPosition(interactorTransform.position);

    }
    public void OnTriggerExit (Collider other){
        Debug.Log("Object left");
        dm.HideDialog();
    }
}
