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
    public string animationTrigger;
    private bool isEventActive = false;
    private bool canTriggerEvent = true;
    public float eventCooldown = 5.0f;
    private Animator animator; // Referenz auf den Animator für die Animation
    private bool collisionHandled = false;


    // Start is called before the first frame update
    void Start()
    {

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();


        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAgentCollisions();
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



    void CheckAgentCollisions()
    {
        NavMeshAgent[] agents = FindObjectsOfType<NavMeshAgent>();

        foreach (NavMeshAgent otherAgent in agents)
        {
            if (otherAgent != navMeshAgent)
            {
                float distance = Vector3.Distance(transform.position, otherAgent.transform.position);

                if (distance < 2.0f && !collisionHandled)
                {
                    // Rufe die Methode auf, wenn die Agenten sich nahe genug sind
                    HandleAgentCollision(otherAgent);
                }
            }
        }
    }

    void HandleAgentCollision(NavMeshAgent otherAgent)
    {
        if (canTriggerEvent) // Annahme: "EventTrigger" ist der Tag des Triggers
        {

            // Stoppe den Agenten
            navMeshAgent.isStopped = true;
            isEventActive = true;

            StartCoroutine(PlayAnimationAndProcessEvent());
            StartCoroutine(ResetCollisionHandling());
            collisionHandled = true;
        }
    }
    

    // Wenn der Agent den Trigger betritt
    void OnCollisionEnter(Collision other)
    {
        if (canTriggerEvent && other.gameObject.CompareTag("EventTrigger")) // Annahme: "EventTrigger" ist der Tag des Triggers
        {
                    Debug.Log("DRINNEN");

            // Stoppe den Agenten
            navMeshAgent.isStopped = true;
            isEventActive = true;

            StartCoroutine(PlayAnimationAndProcessEvent());

        }
    }

    // Coroutine, die das Event behandelt (hier als Platzhalter)
    IEnumerator PlayAnimationAndProcessEvent()
    {
        // Trigger die Animation
        animator.SetBool(animationTrigger,true);

        // Warte, bis die Animation beendet ist
        float currentAnimationTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime * animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(currentAnimationTime);
                animator.SetBool(animationTrigger,false);

        //yield return new WaitForSeconds(3f);
        // Setze das Event zurück, damit der Agent weitergeht
        isEventActive = false;
        navMeshAgent.isStopped = false;

        // Setze auch das Triggering für das nächste Event zurück
        StartCoroutine(EventCooldown());
    }
    // Coroutine f�r die Abklingzeit des Events
    IEnumerator EventCooldown()
    {
        canTriggerEvent = false; // Deaktiviere das Event-Triggering

        yield return new WaitForSeconds(eventCooldown);

        canTriggerEvent = true; // Aktiviere das Event-Triggering nach der Abklingzeit
    }

     IEnumerator ResetCollisionHandling()
    {
        yield return new WaitForSeconds(5.0f); // npassen der Wartezeit hier (z.B. 5 Sekunden)
        collisionHandled = false; // Erlaube erneute Kollisionsbehandlung
    }

}