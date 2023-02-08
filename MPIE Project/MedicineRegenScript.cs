using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineRegenScript : MonoBehaviour
{
    public GameObject MedicineBottle;
    public GameObject MedicineBottleTop;
    public GameObject MedicineBottleBottom;

    Collider MedicineCollider;

    public float timer; 

    void Start()
    {
        timer = 0;
        MedicineCollider = MedicineBottle.GetComponent<Collider>(); // accesses the medicine bottle's collider
    }


    void Update()
    {
        timer -= Time.deltaTime; //timer number is continually decreasing

        if(timer <= 0) //code re-enables the attributes of the medicine bottle without disabling the timer, as by using MedicineBottle.setActive(false), the timer would turn off and the medicine bottle would not reset
        {
            MedicineBottleTop.SetActive(true);
            MedicineBottleBottom.SetActive(true);
            MedicineCollider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) //code so that when the collider touches the player, the attributes of the medicine bottle are changed to false until the timer is reset to 0
    {
        if (other.CompareTag("Player"))
        {
            MedicineBottleTop.SetActive(false);
            MedicineBottleBottom.SetActive(false);
            MedicineCollider.enabled = false;
            timer = 30.0f;
        }
    }
}
