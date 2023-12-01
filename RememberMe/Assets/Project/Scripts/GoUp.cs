using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    public GameObject obj;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj != null)
        {
            obj.transform.position += Vector3.up * speed;
        }
        else
        {
            gameObject.transform.position += Vector3.up * speed;
        }
    }
}
