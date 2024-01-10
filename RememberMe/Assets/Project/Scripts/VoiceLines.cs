using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    public AudioClip voiceLine;

    private AudioSource audioSource;

    public string[] dialog;
    void Start()
    {
        // AudioSource-Komponente abrufen oder hinzufügen
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Voice Line zuweisen
        audioSource.clip = voiceLine;
        audioSource.maxDistance = 2;
        audioSource.spatialBlend = 1;
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Head")){
            audioSource.Play();
        }
    }
}
