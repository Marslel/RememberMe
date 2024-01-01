using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelSettings : MonoBehaviour
{

     [SerializeField]
    public Data_Storage data_Storage;
    public List<GameObject> MazePrefabs;

    Random rnd;
    // Start is called before the first frame update
    void Start()
    {
        rnd = new Random();
        data_Storage.setMazePrefabs(MazePrefabs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLevel1(){
        data_Storage.setLevel(1);
        //int random = rnd.Next(2);
        data_Storage.setMazePrefabIndex(0);
        data_Storage.time = 3600;
        data_Storage.mazetime = 1000;
    }

        public void setLevel2(){
        data_Storage.setLevel(2);
        data_Storage.setMazePrefabIndex(1);
        data_Storage.time = 1900;
        data_Storage.mazetime = 800;
    }

        public void setLevel3(){
        data_Storage.setLevel(3);
        data_Storage.setMazePrefabIndex(1);
        data_Storage.time = 1500;
        data_Storage.mazetime = 600;
    }
}
