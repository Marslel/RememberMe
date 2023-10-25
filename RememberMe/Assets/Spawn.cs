using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSCript : MonoBehaviour
{
   
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public int Inspector;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(0, 1, 1), Quaternion.identity);
    }
   
}
