using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;


    public float initlialSpeed;

    private GameObject newBullet;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Spawn();
            Invoke("Sleep", 3f);
        }
    }

    public void Spawn(){
        newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * initlialSpeed;
        Invoke("DestroyObject", 3f);
        
    }

    void DestroyObject(){
        Destroy(newBullet);
    }

    void Sleep(){
        Debug.Log("Cooldown");
    }
}
