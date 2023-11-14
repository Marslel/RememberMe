using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSound : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource; 

    public float volume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Spiele den Sound ab
            PlaySound();
        }
    }
    void PlaySound()
    {
        // Setze den AudioClip für die AudioSource
        audioSource.clip = soundClip;

        //Setze die Lautstärke
        audioSource.volume = volume;

        // Spiele den Sound ab
        audioSource.Play();
    }
}
