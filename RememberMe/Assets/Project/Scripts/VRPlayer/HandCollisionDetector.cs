using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollisionDetector : MonoBehaviour
{


    [SerializeField, Range(0, 0.5f)]
    private float detectionDelay = 0.05f;


    [SerializeField]
    private float detectionDistance = 0.2f;
    [SerializeField]
    private LayerMask detectionLayers;
    public List<RaycastHit> DetectedColliderHits { get; private set; }

    private float currentTime = 0;


    private GameObject leftHand;
    private GameObject rightHand;




    private List<RaycastHit> PerformDetection(Vector3 position, Vector3 handLeftDir, float distanceLeft, Vector3 handRightDir, float distanceRight, LayerMask mask){
        
        List<RaycastHit> detectedHits = new();


        RaycastHit hit;

        if (Physics.Raycast(position, handLeftDir, out hit, distanceLeft, mask))
        {
            detectedHits.Add(hit);
        }


        if (Physics.Raycast(position, handRightDir, out hit, distanceRight, mask))
        {
            detectedHits.Add(hit);
        }
        
        return detectedHits;
    }


    private void Start()
    {


        leftHand =  GameObject.Find("HandColliderLeft(Clone)");
        rightHand = GameObject.Find("HandColliderRight(Clone)");
        //DetectedColliderHits = PreformDetection(transform.position,
        //   detectionDistance, detectionLayers);
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > detectionDelay)
        {
            currentTime = 0;
            

            Vector3 posLeftHand = leftHand.GetComponent<Transform>().position;
            Vector3 posRightHand = rightHand.GetComponent<Transform>().position;


            float distanceHeadLeftHand = Vector3.Distance(transform.position, posLeftHand);
            float distanceHeadRightHand = Vector3.Distance(transform.position, posRightHand);



            DetectedColliderHits = PerformDetection(transform.position, posLeftHand, distanceHeadLeftHand, posRightHand, distanceHeadRightHand, detectionLayers);
        }
    }





}