using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    [SerializeField]
    AudioSource audioSource;

    // start time of the soud file in seconds
    [SerializeField]
    float startTime;

    [SerializeField]
    float audioSpeed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource. pitch =audioSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
        audioSource.time = 0.0f;
        audioSource.Play();

    }

    public void playSoundAtSpecificTime()
    {
        if(startTime > audioSource.clip.length)
        {
            return;
        }
        else
        {
            audioSource.time = startTime;
            audioSource.Play();
        }
    }
}
