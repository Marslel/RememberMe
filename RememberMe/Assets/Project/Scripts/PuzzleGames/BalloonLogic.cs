using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonLogic : MonoBehaviour
{
    [SerializeField]
    Animation ani;
    [SerializeField]
    Transform pos;
    Vector3 startPos;
    [SerializeField]
    Collectables col;

    // Start is called before the first frame update
    void Start()
    {
        startPos = pos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.tag == "Player"){
            ani.Play("airballoon");
            col.addPuzzlePiece();

            

        }
    }    

    public void setBaloonPosition(){
        pos.position = (startPos + new Vector3(-198.2f,150.3f,134.6f));
    }

}
