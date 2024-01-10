using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndToBeginning : MonoBehaviour
{
    void Start()
    {

        Invoke("WechsleSzene", 60f); 
    }

    void WechsleSzene()
    {

        SceneManager.LoadScene("StartScene");
    }
}
