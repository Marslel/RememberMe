using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{   
    public Data_Storage data_Storage;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (data_Storage.time == 0){
            SceneManager.LoadScene("Eclipse");
        }
    }
}
