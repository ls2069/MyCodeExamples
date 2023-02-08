using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public float health;

    public AudioSource MedBottleSFX; //these 3 lines of code take the sound effects from the audiosources that are attached to gameobjects
    public AudioSource HurtSFX;
    public AudioSource DeathSFX;


    void OnTriggerEnter(Collider other)
    {
        if (health <= 0)
        {
            DeathSFX.Play(); //death sound effect plays when health is below 0
            return;
        }

        if (other.CompareTag("Spinner"))
        {
            health -= 20; //these two lines of code decrease health by 20 everytime the player enters a "Spinner" triggerbox and play the hurt sound effect
            HurtSFX.Play();
        }

        if (other.CompareTag("Puncher"))
        {
            health -= 10; //these two lines of code decrease health by 10 everytime the player enters a "Puncher" triggerbox and play the hurt sound effect
            HurtSFX.Play();
        }

        if (other.CompareTag("Medicine"))
        {
            health += 50; //these two lines of code increase health by 50 everytime the player enters a "Medicine" triggerbox and play the medicine bottle sound effect
            MedBottleSFX.Play();
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            health -= 1; //this code decreases health by 1 when the player enters the water triggerbox
            if (HurtSFX.isPlaying) //these lines of code stop the hurt sound effect playing continuously and glitching out by only playing the next sound effect when the current one is not playing
            {

            }
            else
            {
                HurtSFX.Play(); 
            }

            
            HurtSFX.Play();
        }
        if (other.CompareTag("Enemy"))
        {
            health -= 2; //this code decreases health by 2 when the player enters the enemy AI triggerbox
            if (HurtSFX.isPlaying) //these lines of code stop the hurt sound effect playing continuously and glitching out by only playing the next sound effect when the current one is not playing
            {

            }
            else
            {
                HurtSFX.Play();
            }
        }
    }
    void Start()
    {
        health = 200; //this code sets the health value as 200 when the player starts the game
    }


    void Update()
    {

        
    }
}
