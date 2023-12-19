using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingUpDownLog : MonoBehaviour
{
    public float moveDistance = 0.3f;
    public float moveSpeed = 1.0f;

    public Vector3 startPosition;

    void Start()
    {
        // Setze die Startposition auf die aktuelle Position des GameObjects (falls nicht im Unity Editor festgelegt)
        startPosition = transform.position;
    }

    void Update()
    {
        float newYPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
        transform.position = startPosition + new Vector3(0f, newYPosition, 0f);
    }

}
