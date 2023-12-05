using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreat : MonoBehaviour
{
    [SerializeField]
    Collectables col;

   [SerializeField]
    Data_Storage dataStorage;

    // Start is called before the first frame update
    void Start()
    {
        if(dataStorage.alpacaTreat){
         collectTreat();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void collectTreat(){
        col.collectTreat();
        this.GetComponent<HideObject>().makeInvisible();
        dataStorage.alpacaTreat = true;
     }

}
