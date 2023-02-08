using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUpdateScript : MonoBehaviour
{
    public KeyCollectScript KeyUpdater;


    void Start()
    {
        
    }


    void Update()
    {
        int KeyNum = KeyUpdater.currentKeyCount; //code takes the keycount number from the KeyCollectScript and set it to the local integer KeyNum

        Text text = gameObject.GetComponent<Text>(); //code recieves the text component from the canvas 

        text.text = KeyNum.ToString(); //converts the integer to a string and displays it on the canvas


    }
}
