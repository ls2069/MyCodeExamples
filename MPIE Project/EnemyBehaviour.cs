using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    public NavMeshAgent EnemyNavMesh;
    public EnemyStates state = EnemyStates.WANDERING; //this sets the Enemy state to wandering at the start, but also allows for it to be changed during testing
    public GameObject player;

    public float targetTime = 5.0f; //these two lines of code are part of the timer system, where targetTime continually decreases until it is reset and updates on whether the state should be FOUND_PLAYER or WANDERING after 10 seconds 
    public float durationTime = 10.0f; 
    public float xRange1; //xRanges and yRanges which are changed in the inspector so the enemies circle around a certain area and return to the area they are guarding if they drift too far away
    public float xRange2;
    public float zRange1;
    public float zRange2;

    public enum EnemyStates //the two states of the switch state
    {

        WANDERING,

        FOUND_PLAYER,
    };
    void Start()
    {
        EnemyNavMesh = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        if (state == EnemyStates.WANDERING)
        {
            float x = Random.Range(xRange1, xRange2); // these two lines of code set the enemy X and Z values to a range determined by the public values so the AI randomly walks around
            float z = Random.Range(zRange1, zRange2);



            EnemyNavMesh.destination = new Vector3(x, 0.0f, z); //code to set the new destination and code to return the speed back to 3.5f when the enemy is wandering
            EnemyNavMesh.speed = 3.5f;
        }

        if (state == EnemyStates.FOUND_PLAYER & targetTime > 0)
        {
            targetTime -= Time.deltaTime; //this decreases target time so that it counts down from 10 seconds to refresh the state
            EnemyNavMesh.destination = player.transform.position; //this code sets the enemy to follow the player
            EnemyNavMesh.speed = 6.5f; // enemy speed is set to 6.5f

        }

        if (state == EnemyStates.FOUND_PLAYER & targetTime < 0)
        {
            targetTime = 10.0f; //this code resets the timer system to 10 seconds 
            state = EnemyStates.WANDERING; //state remains at WANDERING until the player enters the triggerbox 
            EnemyNavMesh.speed = 6.5f; // enemy speed is set to 6.5f

        }

    }

    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player")) // these lines of code identify if an object with the player tag has entered the trigger box, then switches the state to FOUND_PLAYER 
        {

            state = EnemyStates.FOUND_PLAYER; 

            player = other.gameObject; //this sets the player as the object to be followed by the AI
        }

    }
}
