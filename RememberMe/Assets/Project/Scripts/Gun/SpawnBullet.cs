using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;


    public float initlialSpeed;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Spawn();
            Invoke("DestroyObject", 3f);
        }
    }

    public void Spawn(){
        
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = transform.forward * initlialSpeed;
        newBullet.transform.parent = transform;
        
    }

    void DestroyObject(){
        Destroy(bullet);
    }
}
