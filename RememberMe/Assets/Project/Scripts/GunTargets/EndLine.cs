using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Valve.VR.InteractionSystem{
public class EndLine : MonoBehaviour{
        public AudioClip voiceLine;  
        private AudioSource audioSource;

        void Start()
        {
            // Füge eine AudioSource-Komponente hinzu, wenn noch keine vorhanden ist
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Weise den gewünschten Audioclip zu
            audioSource.clip = voiceLine;
        }
        public void PlayVoiceLine()
        {
            if (voiceLine != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}