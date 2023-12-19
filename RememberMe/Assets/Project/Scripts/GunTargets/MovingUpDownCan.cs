using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpDownCan : MonoBehaviour
{
    private bool isCooldownActive = false;

    public WinTheGame winthegame;

    public GameObject CanDestroy;

    public float moveDistance = 0.3f;
    public float moveSpeed = 1.0f;

    public Vector3 startPosition;


    void Start(){
        winthegame = GameObject.FindGameObjectWithTag("House").GetComponent<WinTheGame>();

        startPosition = transform.position;
    }

    void Update()
    {
        float newYPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
        transform.position = startPosition + new Vector3(0f, newYPosition, 0f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!isCooldownActive && collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Kollision mit: " + collision.gameObject.name);
            winthegame.collectPoints();
            Debug.Log("Punkte: " + winthegame.points);

            // Setze den Cooldown-Zustand auf aktiv und starte die Coroutine
            isCooldownActive = true;
            StartCoroutine(StartCooldown());
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
