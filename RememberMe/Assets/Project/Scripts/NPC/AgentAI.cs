using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{

    public List<Transform> wayPoint;

    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public int currentWayPointIndex = 0;
    public float waitTime = 2.0f;
    private float waitTimer;
    public bool shouldStop;

    private bool isEventActive = false;
    private bool canTriggerEvent = true;
    public float eventCooldown = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEventActive) // F�hre die normale Bewegung des Agenten aus, wenn das Event nicht aktiv ist
        {
            Walking();
        }
    }

    void Walking(){

        


        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime && shouldStop)
            {
                
                currentWayPointIndex = (currentWayPointIndex + 1) % wayPoint.Count;
                SetDestination();
                waitTimer = 0f;
            }
            else
            {
                currentWayPointIndex = (currentWayPointIndex + 1) % wayPoint.Count;
                SetDestination();
            }
                

        }

        //navMeshAgent.SetDestination(wayPoint[currentWayPointIndex].position);
        
    }
    void SetDestination()
    {
        if (wayPoint.Count == 0) return;

        Vector3 targetPosition = wayPoint[currentWayPointIndex].position;
        navMeshAgent.SetDestination(targetPosition);
    }




    

    // Wenn der Agent den Trigger betritt
    void OnCollisionEnter(Collision other)
    {
        
        if (canTriggerEvent && other.gameObject.name == "HandColliderRight(Clone)"|| other.gameObject.name == "HandColliderLeft(Clone)") // Annahme: "EventTrigger" ist der Tag des Triggers
        {

            // Stoppe den Agenten
            navMeshAgent.isStopped = true;
            isEventActive = true;

            // Hier kannst du die Logik f�r das Event ausf�hren
            // Zum Beispiel: Coroutine starten, die das Event durchf�hrt
            StartCoroutine(ProcessEvent());

            // Starte den Cooldown-Timer f�r das erneute Ausl�sen des Events
            StartCoroutine(EventCooldown());
        }
    }

    // Coroutine, die das Event behandelt (hier als Platzhalter)
    IEnumerator ProcessEvent()
    {
        // F�hre das Event aus (z. B. Dialog, Animation, usw.)
        Debug.Log("Event gestartet...");

        // Hier w�rde deine Event-Logik stehen, die den Agenten stoppt

        // Simuliere eine Verz�gerung
        yield return new WaitForSeconds(3.0f);

        // Setze das Event zur�ck, damit der Agent weitergeht
        isEventActive = false;
        navMeshAgent.isStopped = false;

        Debug.Log("Event abgeschlossen. Agent l�uft weiter.");
    }

    // Coroutine f�r die Abklingzeit des Events
    IEnumerator EventCooldown()
    {
        canTriggerEvent = false; // Deaktiviere das Event-Triggering

        yield return new WaitForSeconds(eventCooldown);

        canTriggerEvent = true; // Aktiviere das Event-Triggering nach der Abklingzeit
    }



}