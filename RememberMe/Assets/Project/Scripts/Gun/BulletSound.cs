using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSound : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource; 

    public float volume = 1.0f;

    private bool canSpawn = true;

    private int maxBullets = 0;
    private int shootBullets = 0;

    SpawnBullet spawnBulletComponent;


    public GameObject objectWithBulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        spawnBulletComponent = objectWithBulletSpawn.GetComponent<SpawnBullet>();

        if(spawnBulletComponent != null){
            maxBullets = spawnBulletComponent.maxBullets;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canSpawn && Input.GetKeyDown(KeyCode.Space) && shootBullets < maxBullets)
        {
            // Spiele den Sound ab
            PlaySound();
            StartCoroutine(StartCooldown());
            shootBullets = spawnBulletComponent.shootBullets;
            shootBullets++;
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

    IEnumerator StartCooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }

}
