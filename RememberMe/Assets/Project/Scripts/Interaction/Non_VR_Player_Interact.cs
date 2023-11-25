using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Non_VR_Player_Interact : MonoBehaviour
{
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        
       /*     float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray){
                if (collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    npcInteractable.Interact();
                }
            }

        
            Collider[] colliderArray2 = Physics.OverlapSphere(transform.position, 0.5f);
            foreach (Collider collider in colliderArray2){
                if (collider.TryGetComponent(out HandInteractable handInteractable)){
                    handInteractable.Interact();
                }
            }
         */   
    }
    public NPCInteractable GetInteractableObject(){
        float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray){
                if (collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    return npcInteractable;
                }
            }
            return null;
    }
}
