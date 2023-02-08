using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetAnimation : MonoBehaviour
{
    public Animator Anim;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnim()
    {
        if (isOpen == false)
        {
            Anim.SetTrigger("OpenDoor");
            isOpen = true;
        }
        else if (isOpen == true)
        {
            Anim.SetTrigger("CloseDoor");
            isOpen = false;

        }
        
    }
}
