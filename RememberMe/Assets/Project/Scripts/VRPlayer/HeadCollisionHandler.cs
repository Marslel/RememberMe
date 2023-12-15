using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private HeadCollisionDetector detector;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    public float pushBackStrength = 1.0f;
    private Vector3 CalculatePushBackDirection(List<RaycastHit> colliderHits)
    {
        Vector3 combinedNormal = Vector3.zero;
        foreach (RaycastHit hitPoint in colliderHits)
        {
            combinedNormal +=
                new Vector3(hitPoint.normal.x, 0, hitPoint.normal.z); ;
        }
        return combinedNormal;
    }

    private void Update()
    {
        if (detector.DetectedColliderHits.Count <= 0)
        {
            return;
        }
        Vector3 pushBackDirection
            = CalculatePushBackDirection(detector.DetectedColliderHits);

        Debug.DrawRay(transform.position, pushBackDirection.normalized, Color.magenta);

        player.transform.position += (pushBackDirection.normalized * pushBackStrength * Time.deltaTime);
        //    .Move(pushBackDirection.normalized * pushBackStrength * Time.deltaTime);
    }
}