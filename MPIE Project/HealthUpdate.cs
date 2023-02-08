using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour
{
    public GameObject player; //identifies that the player 
    public float health = 0; 
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        float healthVal = player.GetComponent<PlayerHealthScript>().health; // healthval receives the health value from the Player gameobject 

        Text healthText = GetComponent<Text>(); //Text component is identified
        healthText.text = healthVal.ToString(); //health val is displayed in the text on the canvas

    }
}
