using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerHealth : MonoBehaviour
{
    public float initialhealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {
        
    }
    public void Difficulty()
    {
        bool EasyMode = false;
        bool NormalMode = false;
        bool HardMode = false;
        bool ImpossibleMode = false;

        if (EasyMode == true)
        {
            initialhealth = 200;
            EasyMode = false;
            Debug.Log("EASYMODE");
        }
        else if (NormalMode == true)
        {
            initialhealth = 100;
            NormalMode = false;
        }
        else if (HardMode == true)
        {
            initialhealth = 50;
            HardMode = false;
        }
        else if (ImpossibleMode == true)
        {
            initialhealth = 1;
            ImpossibleMode = false;
        }
        
    }


}
