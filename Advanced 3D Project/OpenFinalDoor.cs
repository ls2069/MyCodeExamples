using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFinalDoor : MonoBehaviour
{
    //each script is linked to its corresponding lever, grabbing the boolean from the script
    public SwitchAnimation switch1;
    public SwitchAnimation switch2;
    public SwitchAnimation switch3;
    public SwitchAnimation switch4;
    public SwitchAnimation switch5;
    public SwitchAnimation switch6;
    //each green and red cube to show the lights, as shader colours cannot be changed
    public GameObject onCube1;
    public GameObject offCube1;

    public GameObject onCube2;
    public GameObject offCube2;

    public GameObject onCube3;
    public GameObject offCube3;

    public GameObject onCube4;
    public GameObject offCube4;

    public GameObject onCube5;
    public GameObject offCube5;

    public GameObject onCube6;
    public GameObject offCube6;
    
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //registers if the switch is turned on, the "else"'s shouldn't be repeated but for some reason the cubes wouldn't turn on and off, so this was the work around
        if (switch1.isOn == true)
        {
            ShowCube1();
        }
        else
        {
            HideCube1();
        }
        if (switch2.isOn == true)
        {
            ShowCube2();
        }
        else
        {
            HideCube2();
        }
        if (switch3.isOn == true)
        {
            ShowCube3();
        }
        else
        {
            HideCube3();
        }
        if (switch4.isOn == true)
        {
            ShowCube4();
        }
        else
        {
            HideCube4();
        }
        if (switch5.isOn == true)
        {
            ShowCube5();
        }
        else
        {
            HideCube5();
        }
        if (switch6.isOn == true)
        {
            ShowCube6();
        }
        else
        {
            HideCube6();
        }
        //registers if all the switches are on, which will "open" the door by setting the door as inactive
        if (switch1.isOn && switch2.isOn && switch3.isOn && switch4.isOn && switch5.isOn && switch6.isOn)
        {
            openDoor();
        }
    }

    void openDoor()
    {
        Door.SetActive(false);
    }

    void ShowCube1()
    {
        onCube1.SetActive(true);
        offCube1.SetActive(false);
    }
    void HideCube1()
    {
        onCube1.SetActive(false);
        offCube1.SetActive(true);
    }
    void ShowCube2()
    {
        onCube2.SetActive(true);
        offCube2.SetActive(false);
    }
    void HideCube2()
    {
        onCube2.SetActive(false);
        offCube2.SetActive(true);
    }

    void ShowCube3()
    {
        onCube3.SetActive(true);
        offCube3.SetActive(false);
    }
    void HideCube3()
    {
        onCube3.SetActive(false);
        offCube3.SetActive(true);
    }

    void ShowCube4()
    {
        onCube4.SetActive(true);
        offCube4.SetActive(false);
    }
    void HideCube4()
    {
        onCube4.SetActive(false);
        offCube4.SetActive(true);
    }

    void ShowCube5()
    {
        onCube5.SetActive(true);
        offCube5.SetActive(false);
    }
    void HideCube5()
    {
        onCube5.SetActive(false);
        offCube5.SetActive(true);
    }

    void ShowCube6()
    {
        onCube6.SetActive(true);
        offCube6.SetActive(false);
    }
    void HideCube6()
    {
        onCube6.SetActive(false);
        offCube6.SetActive(true);
    }
}
