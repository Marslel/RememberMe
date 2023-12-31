using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    private bool isCooldownActive = false;

    public GameObject prefabToLoad;
    public WinTheGame winthegame;

    public GameObject CanDestroy;

    

    void Start(){
        winthegame = GameObject.FindGameObjectWithTag("House").GetComponent<WinTheGame>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!isCooldownActive && collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Kollision mit: " + collision.gameObject.name);
            winthegame.collectPoints();
            Debug.Log("Punkte: " + winthegame.points);

            GameObject instantiatedPrefab = Instantiate(prefabToLoad, transform.position, Quaternion.identity);
            // Setze den Cooldown-Zustand auf aktiv und starte die Coroutine
            isCooldownActive = true;
            StartCoroutine(StartCooldown());
            Destroy(instantiatedPrefab);
            Destroy(CanDestroy);
        }
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(2);

        // Setze den Cooldown-Zustand nach Ablauf der Zeit zurück
        isCooldownActive = false;
    }
}
