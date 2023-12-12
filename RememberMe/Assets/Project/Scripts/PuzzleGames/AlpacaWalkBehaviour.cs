using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlpacaWalkBehaviour : MonoBehaviour
{
    public GameObject walkingArea;
    public GameObject player;
    public float targetDistance;
    public float allowedDistance = 2;

    private float currentDistance;

    public RaycastHit Shot;

    private Animator animator;
    
    public NavMeshAgent alpacca;

    public Collectables col;

    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;

    // Start is called before the first frame update
    void Start()
    {
        currentDistance = 0;
        animator = GetComponent<Animator>();
        //alpacca = GetComponent<NavMeshAgent>();
        if(alpacca != null){
            alpacca.speed = speed;
            alpacca.SetDestination(RandomNavMeshLocation());
            animator.Play("Alpaca Run Layer.Idle");
        }
    }

    // Update is called once per frame
    void Update()
    {


         if(alpacca != null && alpacca.remainingDistance <= alpacca.stoppingDistance){
            animator.Play("Alpaca Run Layer.Walk");
            alpacca.speed = 1f;
            alpacca.SetDestination(RandomNavMeshLocation());
        }


        //transform.LookAt(player.transform);


        // if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)){
        //     targetDistance = Shot.distance;
        //     animator.SetFloat("DistanceFromPlayer",targetDistance);
        //     if(targetDistance >= 15){
        //         speed = 0.1f;
        //         animator.Play("Alpaca Run Layer.Run");

        //         transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z), followSpeed);

        //     }else if(targetDistance >= 3 ){
        //         speed = 0.03f;
        //         animator.Play("Alpaca Run Layer.Walk");

        //         transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z), followSpeed);
            
        //     } else{
        //         speed = 0f;
        //         animator.Play("Alpaca Run Layer.Idle");
               

        //     }
            
        // }
        
    }

     private void OnTriggerEnter(Collider other){
        if(col!=null && other.tag == "Head" && !col.alpacaIgnorePlayer){

        if(alpacca != null &&!col.treatCollected){

            // alpaca runs away from player
            animator.Play("Alpaca Run Layer.Run");
            alpacca.speed = 9f;
            alpacca.SetDestination(SpecificNavMeshLocation(new Vector3(transform.position.x - player.transform.position.x +10,- player.transform.position.y ,transform.position.z- player.transform.position.z +10)));

        }else if(alpacca != null && col.treatCollected){
            // alpaca comes to player
            animator.Play("Alpaca Run Layer.Run");
            alpacca.speed = 3f;       
            alpacca.SetDestination(SpecificNavMeshLocation(player.transform.position));
        }

        }
     }

        private void OnTriggerStay(Collider other){
       


        if(alpacca != null &&!col.treatCollected){
            // alpaca runs away from player
            animator.Play("Alpaca Run Layer.Run");
            alpacca.speed = 9f;
            alpacca.SetDestination(SpecificNavMeshLocation(new Vector3(transform.position.x - player.transform.position.x +10,- player.transform.position.y ,transform.position.z- player.transform.position.z +10)));

        }else if(alpacca != null && col.treatCollected){
            // alpaca comes to player
            currentDistance =  Vector3.Distance(this.transform.position, player.transform.position);
            if(currentDistance > 9){
                animator.Play("Alpaca Run Layer.Run");
                alpacca.speed = 3f;
            } else if(currentDistance <= 9 && currentDistance > 3){
                animator.Play("Alpaca Run Layer.Walk");
                alpacca.speed = 1f;
            } else{
                animator.Play("Alpaca Run Layer.Idle");
                alpacca.speed = 0f;
            }
            alpacca.SetDestination(SpecificNavMeshLocation(player.transform.position));
        }

    
     }


    public Vector3 SpecificNavMeshLocation(Vector3 pos){

        Vector3 finalPosition = Vector3.zero;
        if(NavMesh.SamplePosition(pos, out NavMeshHit hit, walkRadius, 1)){
            finalPosition = hit.position;
        }
        return finalPosition;
    }
    public Vector3 RandomNavMeshLocation(){

        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if(NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1)){
            finalPosition = hit.position;
        }
        return finalPosition;
    }


}
