using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHat : MonoBehaviour
{

    [SerializeField]
    GameObject alpacaHat;

    [SerializeField]
    GameObject newHat;

    UnityEngine.Vector3 pos;
    UnityEngine.Quaternion rot;
    bool hatSwapped;



    // Start is called before the first frame update
    void Start()
    {
        hatSwapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Head" && !hatSwapped){
            pos = alpacaHat.transform.position;
            rot = alpacaHat.transform.rotation;
            newHat.transform.position = pos;
            newHat.transform.rotation = rot;
            newHat.GetComponent<HideObject>().makeVisible();
            alpacaHat.GetComponent<HideObject>().makeInvisible();
            hatSwapped = true;


        }
    }


}
