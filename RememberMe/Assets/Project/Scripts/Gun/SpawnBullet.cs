using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class SpawnBullet : MonoBehaviour
    {
        public GameObject bullet;
        public float initialSpeed;
        private GameObject newBullet;
        private bool canSpawn = true;
        public int maxBullets = 0;
        public int shootBullets = 0;

        public SteamVR_Action_Boolean gunTrigger = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
        private SteamVR_Input_Sources handTypeleft;
        private SteamVR_Input_Sources handTyperight;

        public StartGame startGame;

        public LineRenderer bulletPathRenderer;
        public int pathResolution = 10; // Anzahl der Punkte in der Flugbahnvisualisierung

        void Start()
        {
            handTyperight = SteamVR_Input_Sources.RightHand;
            handTypeleft = SteamVR_Input_Sources.LeftHand;

            bulletPathRenderer.positionCount = pathResolution;
            bulletPathRenderer.enabled = true;
        }

        void Update()
        {
            if (canSpawn && (Input.GetKeyDown(KeyCode.Space) || gunTrigger.GetStateDown(handTypeleft) || gunTrigger.GetStateDown(handTyperight)) && shootBullets < maxBullets && startGame.hasTriggered)
            {
                Spawn();
                StartCoroutine(StartCooldown());
                shootBullets++;
            }

            if (shootBullets == maxBullets)
            {
                startGame.DeleteList();
                shootBullets = 0;
            }
        }

        public void Spawn()
        {
            newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;

            // Aktiviere die Flugbahnanzeige und starte die Berechnung
            bulletPathRenderer.enabled = true;
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

        void FixedUpdate()
        {
           if(startGame.level == 1){
                VisualizeBulletPath();
           }
        }

        void VisualizeBulletPath()
        {
            for (int i = 0; i < pathResolution; i++)
            {
                float t = i / (float)(pathResolution - 1);
                Vector3 position = CalculateBulletPosition(t);
                bulletPathRenderer.SetPosition(i, position);
            }
        }

        Vector3 CalculateBulletPosition(float t)
        {
            float g = Physics.gravity.y;
            Vector3 initialPosition = transform.position;
            Vector3 initialVelocity = transform.forward * initialSpeed;

            Vector3 position = initialPosition + initialVelocity * t + 0.5f * g * t * t * Vector3.up;

            return position;
        }
    }
}