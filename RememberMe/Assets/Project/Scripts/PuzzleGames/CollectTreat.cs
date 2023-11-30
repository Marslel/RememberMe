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
     public void collectTreat(){
        col.collectTreat();
        this.GetComponent<HideObject>().makeInvisible();
     }

}
