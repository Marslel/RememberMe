using UnityEngine;
using Valve.VR;

public class NPCInteraction : MonoBehaviour
{
    public LayerMask npcLayer;
    public GameObject dialogueCanvas;

    private void OnTriggerStay(Collider other)
    {
        if (npcLayer == (npcLayer | (1 << other.gameObject.layer)))
        {
            if (SteamVR_Input.GetStateDown("Interact", SteamVR_Input_Sources.Any))
            {
                // Hier Code für Konversationsstart mit NPC einfügen
                StartConversation();
            }
        }
    }

    private void StartConversation()
    {
        // Hier implementierst du die Logik für den Konversationsstart
        Debug.Log("Konversation mit NPC gestartet: " + this.name);
    }
}
