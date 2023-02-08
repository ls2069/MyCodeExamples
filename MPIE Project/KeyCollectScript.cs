using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KeyCollectScript : MonoBehaviour
{
    public AudioSource KeyCollectSFX; 
    public int currentKeyCount = 0; //sets the keynumber to 0 at the start of the game

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Key") //when the player enters the key triggerbox, the current keycount increases by 1 and the sound effect plays, then the key is set to inactive so it cannot be collected again
        {
            currentKeyCount += 1;
            KeyCollectSFX.Play();

            other.gameObject.SetActive(false);
        }
    }
}
