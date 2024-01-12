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
    public AudioClip[] voiceLine;

    private AudioSource audioSource;

    public int dialogueIndex;

    private int currentIndex;

    public int test;

    [SerializeField]
    Data_Storage data;

    private System.DateTime timer = System.DateTime.Now.AddDays(10);

    private void Awake(){
        //animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
        dialogueIndex = data.pianoWon == true ? 1 : 0;


         // AudioSource-Komponente abrufen oder hinzufügen
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Voice Line zuweisen
        audioSource.clip = voiceLine[dialogueIndex];
        audioSource.maxDistance = 2;
        audioSource.spatialBlend = 1;
        
    }

    private void UpdateDialogue(){
            audioSource.Stop();
            dm.HideDialog();
            dm.beginDialogue(dialogue, dialogueIndex );
            audioSource.clip = voiceLine[dialogueIndex];
            audioSource.Play();

    }

    
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Head")){
            dm.beginDialogue(dialogue, dialogueIndex );
            audioSource.clip = voiceLine[dialogueIndex];
            audioSource.Play();
            currentIndex = dialogueIndex;
            timer = System.DateTime.Now;
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
            if(!data.pianoWon && System.DateTime.Now > timer.AddMilliseconds(test) && !data.pianoWon){
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
