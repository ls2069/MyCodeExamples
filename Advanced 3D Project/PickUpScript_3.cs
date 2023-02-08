using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript_3 : MonoBehaviour
{
    /**
* This script is based upon an interaction script from a YouTube video Tutorial
*
* Author: Code Monkey (author name unknown)
* Location: https://www.youtube.com/watch?v=2IhzPTS4av4
* Accessed: 20/10/2021
*/
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float range = 2;

    private ObjectGrabbable objectGrabbable;
    // I added the public bool isHeld to pass along if the object is held to the UI script
    public bool isHeld = false;
    //my code modification ends here
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null) {
                //tries to grab object when not carrying it
                Ray RayFromCamera = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(RayFromCamera, out RaycastHit raycastHit, range))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        //I added the bool change to true
                        isHeld = true;
                        //my code modification ends here
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                //I added the bool to change to false
                isHeld = false;
                //my code modification ends here
                //currently carrying something, then drops 
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
