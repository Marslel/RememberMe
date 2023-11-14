using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public Transform interactorTransform;
    private Animator animator;
    private NPCHeadLookAt npcHeadLookAt;

    private void Awake(){
        animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(){
        Debug.Log("Interact!");
        Debug.Log(interactorTransform.position);
        float playerHeight = 1.7f;
        npcHeadLookAt.LookAtPosition(interactorTransform.position);
    }
}
