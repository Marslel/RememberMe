using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    public float initlialSpeed;
    private GameObject newBullet;
    private bool canSpawn = true;
    public int maxBullets = 0;
    public int shootBullets = 0;

    public StartGame startGame;


    void Update()
    {
        if(canSpawn && Input.GetKeyDown(KeyCode.Space) && shootBullets < maxBullets){
            Spawn();
            StartCoroutine(StartCooldown());
            shootBullets++;
        }
        if(shootBullets == maxBullets){
            startGame.DeleteList();

            shootBullets = 0;
        }
    }

    public void Spawn(){
        newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * initlialSpeed;
    }

    void DestroyObject(){
        Destroy(newBullet);
    }

    IEnumerator StartCooldown(){
        canSpawn = false;
        yield return new WaitForSeconds(2);
        DestroyObject();
        canSpawn = true;
    }
}
