using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRightLeftLog : MonoBehaviour
{
    public float moveDistance = 0.3f;
    public float moveSpeed = 1.0f;

    public MovingRightLeftCan can;

    void Update()
    {
        float newPosition = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision other)
    {
        // Wenn das GameObject mit einer anderen Hitbox kollidiert, kehre die Bewegung um
        if (other.gameObject.CompareTag("Log"))  // Ersetze "YourTag" durch den tatsächlichen Tag der Hitbox
        {
            moveSpeed *= -1; // Ändere die Bewegungsrichtung
            can.moveSpeed *= -1;
        }
    }
}
