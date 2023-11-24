using UnityEngine;
using Valve.VR.InteractionSystem;

public class NPCInteraction : MonoBehaviour
{
     public DialogManager dialogManager;
    public float interactDistance = 0.5f;
    

    private void HandHoverUpdate(Hand hand)
    {
        // Überprüfe, ob die Hand in der Nähe ist
        if (Vector3.Distance(transform.position, hand.transform.position) < interactDistance)
        {
            // NPC-Interaktion hier auslösen
            InteractWithNPC();
        }
    }

    private void InteractWithNPC()
    {
        // Spieler hat mit dem NPC interagiert, zeige das Dialogfenster an
            Vector3 npcPosition = transform.position; // Position des NPCs
        // Füge hier den Code für die NPC-Interaktion hinzu
        Debug.Log("NPC interagiert mit dem Spieler.");
        dialogManager.ShowDialog( npcPosition);
    }
}
