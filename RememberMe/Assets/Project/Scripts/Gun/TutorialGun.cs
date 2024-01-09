using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class TutorialGun : MonoBehaviour
    {
        public GameObject bullet;
        public float initialSpeed;
        private GameObject newBullet;
        private bool canSpawn = true;
        public int maxBullets = 0;
        public int shootBullets = 0;

        public GameObject gun;

        public SteamVR_Action_Boolean gunTrigger = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
        private SteamVR_Input_Sources handTypeleft;
        private SteamVR_Input_Sources handTyperight;

        void Start()
        {
            handTyperight = SteamVR_Input_Sources.RightHand;
            handTypeleft = SteamVR_Input_Sources.LeftHand;
        }

        void Update()
        {
            if (canSpawn && (Input.GetKeyDown(KeyCode.Space) || gunTrigger.GetStateDown(handTypeleft) || gunTrigger.GetStateDown(handTyperight)) && shootBullets < maxBullets)
            {
                
                Spawn();
                StartCoroutine(StartCooldown());
                shootBullets++;

                if(shootBullets == 1){
                    Invoke("DestroyGun", 5f);
                }
            }
        }

        public void Spawn()
        {
            newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;

        }

        void DestroyObject()
        {
            Destroy(newBullet);
        }

        IEnumerator StartCooldown()
        {
            canSpawn = false;
            yield return new WaitForSeconds(2);
            DestroyObject();

            

            canSpawn = true;
        }

        void DestroyGun(){
            Destroy(gun);
        }
    }
}