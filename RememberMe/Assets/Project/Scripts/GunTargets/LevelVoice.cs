using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Valve.VR.InteractionSystem{
public class LevelVoice : MonoBehaviour{
        public AudioClip voiceLine1;  
        public AudioClip voiceLine2; 
        public AudioClip voiceLine3; 
        private AudioSource audioSource;

        void Start()
        {
            // Füge eine AudioSource-Komponente hinzu, wenn noch keine vorhanden ist
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

        }

        public void LevelPlay(int level){
            if (level == 1){
                audioSource.clip = voiceLine1;
                PlayVoiceLine(voiceLine1);
            } else if(level == 2){
                audioSource.clip = voiceLine2;
                PlayVoiceLine(voiceLine2);
            } else{
                audioSource.clip = voiceLine3;
                PlayVoiceLine(voiceLine3);
            }
        }
        public void PlayVoiceLine(AudioClip voiceLine)
        {
            if (voiceLine != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}