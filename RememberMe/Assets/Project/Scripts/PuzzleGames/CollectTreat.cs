using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreat : MonoBehaviour
{
    [SerializeField]
    Collectables col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider other){
        
        if(col!=null && other.tag == "Player"){

            col.collectTreat();
            this.GetComponent<HideObject>().makeInvisible();

        }
     }

}
