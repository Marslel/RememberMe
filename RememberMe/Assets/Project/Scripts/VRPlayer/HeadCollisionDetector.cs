using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionDetector : MonoBehaviour
{
    [SerializeField, Range(0, 0.5f)]
    private float detectionDelay = 0.05f;
    [SerializeField]
    private float detectionDistance = 0.2f;
    [SerializeField]
    private LayerMask detectionLayers;
    public List<RaycastHit> DetectedColliderHits { get; private set; }

    private float currentTime = 0;

    private List<RaycastHit> PreformDetection
    (Vector3 position, float distance, LayerMask mask)
    {
        List<RaycastHit> detectedHits = new();

        List<Vector3> directions
            = new() { transform.forward, transform.right, -transform.right };

        RaycastHit hit;
        foreach (var dir in directions)
        {
            if (Physics.Raycast(position, dir, out hit, distance, mask))
            {
                detectedHits.Add(hit);
            }
        }
        return detectedHits;
    }

    private void Start()
    {
        DetectedColliderHits = PreformDetection(transform.position,
           detectionDistance, detectionLayers);
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > detectionDelay)
        {
            currentTime = 0;
            DetectedColliderHits = PreformDetection(transform.position,
                detectionDistance, detectionLayers);
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying == false)
            return;
        Color c = Color.green;
        c.a = 0.5f;
        if (DetectedColliderHits.Count > 0)
        {
            c = Color.red;
            c.a = 0.5f;
        }

        Gizmos.color = c;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);

        List<Vector3> directions = new() { transform.forward, transform.right, -transform.right };
        Gizmos.color = Color.magenta;
        foreach (var dir in directions)
        {
            Gizmos.DrawRay(transform.position, dir);
        }
    }
}