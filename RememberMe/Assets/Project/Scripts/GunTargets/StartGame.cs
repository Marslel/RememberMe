using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public bool hasTriggered = false;

    public GameObject[] prefabToSpawn;
    public int numberOfObjectsToSpawn;
    private ObjectSpawner objectSpawner;

    void Start(){
        objectSpawner = gameObject.AddComponent<ObjectSpawner>();
    }

    private void OnTriggerEnter(Collider other){
        if (!hasTriggered){
            Debug.Log("Spieler durch die Hitbox gelaufen");
            objectSpawner.SpawnObjects(numberOfObjectsToSpawn, prefabToSpawn);
            hasTriggered = true;
        }
    }

    public void DeleteList(){
        objectSpawner.Invoke("DeleteList", 2);
        hasTriggered = false;
    }
}
