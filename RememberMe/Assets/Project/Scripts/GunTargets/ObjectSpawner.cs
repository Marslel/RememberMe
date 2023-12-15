using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private GameObject[] spawnedGameObjekcList;

    void Start(){
        spawnedGameObjekcList = new GameObject[100];
    }

    public void SpawnObjects(int numberOfObjectsToSpawn, GameObject[] prefabToSpawn){
        for (int i = 0; i < numberOfObjectsToSpawn; i++){
            GameObject spawnedGameObject;

            do{
            int randomIndex = Random.Range(0, prefabToSpawn.Length);
            float randomX = Random.Range(-14f,-11f);
            float randomZ = Random.Range(-14f, -6f);
            Vector3 randomSpawnPosition = new Vector3(randomX, -0.55f, randomZ);

            spawnedGameObject = Instantiate(prefabToSpawn[randomIndex], randomSpawnPosition, Quaternion.identity);


            

            }while(IsObjectInsideCollider(spawnedGameObject, i));

            spawnedGameObjekcList[i] = spawnedGameObject;
        }
    }

    public bool IsObjectInsideCollider(GameObject objToCheck, int currentIndex){
        if(spawnedGameObjekcList.Length > 1){
            for(int i = 0; i < currentIndex; i++){
                if(spawnedGameObjekcList[i].GetComponentInChildren<BoxCollider>().bounds.Intersects(objToCheck.GetComponentInChildren<BoxCollider>().bounds)){
                    Debug.LogWarning("Collider ist im Collider");
                    Destroy(objToCheck);
                    return true;
                }
            }
            return false;
        }
        return false;
    }

    public void DeleteList(){
        //Hier 2 Sekunden warten
        
        // Iteriere durch das Array und zerstöre jedes GameObject.

        Debug.Log("Listemgröße" + spawnedGameObjekcList.Length);
        foreach (GameObject obj in spawnedGameObjekcList)
        {
            // Überprüfe, ob das GameObject gültig ist, bevor du versuchst, es zu zerstören.
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }
    
}
