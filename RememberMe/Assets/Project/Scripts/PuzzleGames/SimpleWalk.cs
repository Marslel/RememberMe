using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWalk : MonoBehaviour

{
     public UnityEngine.AI.NavMeshAgent npc;
    [Range(1, 500)] public float walkRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(npc != null && npc.remainingDistance <= npc.stoppingDistance){
            npc.speed = 1f;
            npc.SetDestination(RandomNavMeshLocation());
        }
        
    }


    public Vector3 RandomNavMeshLocation(){

        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if(UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out UnityEngine.AI.NavMeshHit hit, walkRadius, 1)){
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
