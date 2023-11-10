using UnityEngine.Events;
using UnityEngine;
using System;

public class GunBehaviourScript : MonoBehaviour
{   
    public UnityEvent onGunShoot;
    public float fireCooldown;

    public Transform orientation;
    private float currentCooldown;

    void Start()
    {
        currentCooldown = fireCooldown;
    }


    void Update()
    {
        if(Input.GetMouseButton(0)){
            if(currentCooldown <= 0f){
                Debug.Log("Shot Gun");
                onGunShoot?.Invoke();
                currentCooldown = fireCooldown;
            }
        }
        currentCooldown -= Time.deltaTime;
    }
}
