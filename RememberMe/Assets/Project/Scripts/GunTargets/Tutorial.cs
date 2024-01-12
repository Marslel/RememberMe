using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Valve.VR.InteractionSystem{
public class Tutorial : MonoBehaviour{
        public AudioClip voiceLine;  

        public bool oneTime = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!oneTime)
            {
                PlayVoiceLine();
                oneTime = true;
            }
        }

        private void PlayVoiceLine()
        {
            AudioSource audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = voiceLine;
            audioSource.Play();
        }
    }
}