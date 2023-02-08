using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
    public bool isOn;
    private AudioSource click_sfx;
    void Start()
    {
        //grabs the component from the individual lever
        click_sfx = GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySwitchAnim()
    {
        //booleans to register that the lever is on/off which reverse the switch and are passed to the door script
        if (isOn == false)
        {
            Anim.SetTrigger("FlickOn");
            click_sfx.Play();
            isOn = true;
        }
        else if (isOn == true)
        {
            Anim.SetTrigger("FlickOff");
            click_sfx.Play();
            isOn = false;

        }

    }
}
