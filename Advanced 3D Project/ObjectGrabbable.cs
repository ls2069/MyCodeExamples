using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    /**
* This script is based upon an interaction script from a YouTube video Tutorial
*
* Author: Code Monkey (author name unknown)
* Location: https://www.youtube.com/watch?v=2IhzPTS4av4
* Accessed: 20/10/2021
*/

    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    public Camera PlayerCamera;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        //when grabbed, the object will be locked to the invisible transform point and removes its gravity and rotation for smooth moving in the air
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        //I added the line to freeze the item's rotation
        objectRigidbody.freezeRotation = true;
        //my code modification ends here
    }

    public void Drop()
    {
        //dropping the object makes the transformm null, giving it back its rigidbody gravity and unlocking its rotation
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        //I added the line to unfreeze the item's rotation
        objectRigidbody.freezeRotation = false;
        //my code modification ends here

    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            // camera track takes the rotation of the player camera
            //I added the below 2 lines to grab the player's camera rotation and transfer it to the object, making the object face the player's camera when it's held
            var PlayerCameraTrack = PlayerCamera.transform.rotation;
            // object rigidbody is then passed on and continuously updated to face the player no matter the camera position
            objectRigidbody.transform.rotation = PlayerCameraTrack;
            //my code modification ends here
            //lerp smooths the object move transition, making it less jittery
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            //object's new position is taken from the player's position and the hidden transform point position
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
