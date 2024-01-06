using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndsceneHappy : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    // start time of the soud file in seconds
    [SerializeField]
    float startTime;

    [SerializeField]
    float volume;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.time = 0.0f;
        if(startTime > audioSource.clip.length)
        {
            return;
        }
        else
        {
            audioSource.volume = volume;
            audioSource.time = startTime;
            audioSource.Play();
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying){
            // return to start Menu
            SceneManager.LoadScene("StartScene");
        }
    }
}
