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

    public Vector3 nextDesination;

    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;


    private List<Vector3> hidingSpots;
    private int index;

    // Start is called before the first frame update
    void Start()
    {   
        index = 0;
        hidingSpots = new List<Vector3>();
        Vector3 corner1 = new Vector3(-58.4f, -0.83f,28.3f );
        Vector3 corner2 = new Vector3(56f, -0.83f,38.9f );
        Vector3 corner3 = new Vector3(47.4f, -0.83f,-45f );
        Vector3 corner4 = new Vector3(-44.4f, -0.83f,-52f );
        hidingSpots.Add(corner1);
        hidingSpots.Add(corner2);
        hidingSpots.Add(corner3);
        hidingSpots.Add(corner4);

        currentDistance = 0;
        animator = GetComponent<Animator>();
        alpacca = GetComponent<NavMeshAgent>();
        // if(alpacca != null){
        //     alpacca.speed = speed;
        //     alpacca.SetDestination(RandomNavMeshLocation());
        //     animator.Play("Alpaca Run Layer.Idle");
        // }
    }

    // Update is called once per frame
    void Update()
    {


         if(alpacca != null && alpacca.remainingDistance <= alpacca.stoppingDistance){
            animator.Play("Alpaca Run Layer.Walk");
            alpacca.speed = 4f;
            alpacca.SetDestination(RandomNavMeshLocation());
        }

        
    }

     private void OnTriggerEnter(Collider other){
        if(col!=null && other.tag == "Head" && !col.alpacaIgnorePlayer){

        if(alpacca != null &&!col.treatCollected){

            // alpaca runs away from player
            animator.Play("Alpaca Run Layer.Run");
            alpacca.speed = 7f;
            alpacca.SetDestination(SpecificNavMeshLocation(hidingSpots[index]));

        }else if(alpacca != null && col.treatCollected){
            // alpaca comes to player
            animator.Play("Alpaca Run Layer.Run");
            alpacca.speed = 3f;       
            alpacca.SetDestination(SpecificNavMeshLocation(player.transform.position));
        }

        }
     }

        private void OnTriggerStay(Collider other){
        if(col!=null && other.tag == "Head" && !col.alpacaIgnorePlayer){


        if(alpacca != null &&!col.treatCollected){
            // alpaca runs away from player
            animator.Play("Alpaca Run Layer.Run");
            alpacca.speed = 7f;
            alpacca.SetDestination(SpecificNavMeshLocation(hidingSpots[index]));

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


    
     }


      private void OnTriggerExit(Collider other){
        if(other.tag == "Head"){
            index = (index + 1) % 3; 
        }
      }


    public Vector3 SpecificNavMeshLocation(Vector3 pos){

        Vector3 finalPosition = Vector3.zero;
        if(NavMesh.SamplePosition(pos, out NavMeshHit hit, walkRadius, 1)){
            finalPosition = hit.position;
            nextDesination = finalPosition;
        }
        return finalPosition;
    }
    public Vector3 RandomNavMeshLocation(){

        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if(UnityEngine.AI.NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1)){
            finalPosition = hit.position;
            nextDesination = finalPosition;
        }
        return finalPosition;
    }


}
