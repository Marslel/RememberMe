using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class StartGame : MonoBehaviour
{
    public bool hasTriggered = false;

    public GameObject[] prefabToSpawn;
    public int numberOfObjectsToSpawn;
    private ObjectSpawner objectSpawner;

    public int level;

    public Data_Storage data_Storage;

    public LevelVoice levelVoice;

    void Start(){
        objectSpawner = gameObject.AddComponent<ObjectSpawner>();

        level = data_Storage.level;
    }

    private void OnTriggerEnter(Collider other){
        if (!hasTriggered){
            Debug.Log("Spieler durch die Hitbox gelaufen");
            if (level == 1){
                levelVoice.LevelPlay(1);
            } else if (level ==2) {
                levelVoice.LevelPlay(2);
            } else {
                levelVoice.LevelPlay(3);
            }
            objectSpawner.SpawnObjects(numberOfObjectsToSpawn, prefabToSpawn);
            hasTriggered = true;
        }
    }

    public void DeleteList(){
        objectSpawner.Invoke("DeleteList", 2);
        hasTriggered = false;
    }
}
