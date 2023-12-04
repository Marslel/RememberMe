using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link2UICamera : MonoBehaviour
{

    Canvas ca; 
    Camera uicamera;

    // Start is called before the first frame update
    void Start()
    {
        ca = GetComponent<Canvas>();
        uicamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
        if(uicamera != null){
            ca.worldCamera = uicamera;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
