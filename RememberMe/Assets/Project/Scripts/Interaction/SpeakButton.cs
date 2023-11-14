using UnityEngine;
using Valve.VR.InteractionSystem;

public class SpeakButton : MonoBehaviour
{
    public GameObject speakButton;
    public float interactDistance = 0.5f;

    private void OnHandHoverUpdate(Hand hand)
    {
        if (Vector3.Distance(transform.position, hand.transform.position) < interactDistance) // Prüfe, ob die Interaktions-Taste auf dem Controller gedrückt ist
        {
            // Hier kannst du die Aktion auslösen, wenn der Spieler auf den "Sprechen"-Button drückt
            SpeakAction();
        }
    }

    private void SpeakAction()
    {
        // Füge hier deine Logik für die Sprechaktion hinzu
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Prüfe, ob der Spieler sich in der Trigger-Zone befindet
        {
            speakButton.SetActive(true); // Aktiviere den "Sprechen"-Button
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Prüfe, ob der Spieler die Trigger-Zone verlässt
        {
            speakButton.SetActive(false); // Deaktiviere den "Sprechen"-Button
        }
    }
}