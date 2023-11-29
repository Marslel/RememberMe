using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabToSpawn;
    public int numberOfObjectsToSpawn;

    private GameObject[] spawnedGameObjekcList;

    // Start is called before the first frame update
    void Start()
    {
        spawnedGameObjekcList = new GameObject[numberOfObjectsToSpawn];
        SpawnObjects();
        
    }

    // Update is called once per frame
    void SpawnObjects(){
        

        for (int i = 0; i < numberOfObjectsToSpawn; i++){

            GameObject spawnedGameObject;

            do{
            int randomIndex = Random.Range(0, prefabToSpawn.Length);
            float randomX = Random.Range(-16f,-12f);
            float randomZ = Random.Range(-13f, -4f);
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
}
