using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxingGloveRandomMove : MonoBehaviour
{
    int randomnum;
    public Animation PunchAnimation;
    

    // Start is called before the first frame update
    void Start()
    {
        PunchAnimation = GetComponent<Animation>();
       
    }

    // Update is called once per frame
    void Update()
    {
        randomnum = Random.Range(1, 100);

        //randomnum *= Time.deltaTime;

        //Debug.Log(randomnum);
        

        if (randomnum == 25)
        {
            PunchAnimation.Play();
            
            
        }
    }
}
