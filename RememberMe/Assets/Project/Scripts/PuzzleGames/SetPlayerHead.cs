using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SetPlayerHead : MonoBehaviour
{

    public MultiAimConstraint aim;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        aim = GetComponentInChildren<MultiAimConstraint>();
        player = GameObject.FindGameObjectWithTag("MainCamera");

          // Get the initial position of the player
        //Vector3 playerInitialPosition = player.transform.position;

        // Set the initial position of the player's head to the player's initial position
        //player.transform.position = playerInitialPosition;


        WeightedTransform weightedTransform = new WeightedTransform {transform = player.transform, weight = 1f};
        var sourceObjects = new WeightedTransformArray();
        sourceObjects.Add(weightedTransform);

        aim.data.sourceObjects=sourceObjects;

    }

    // Update is called once per frame
    void Update()
    {


    }
}
