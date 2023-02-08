using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask Anim;
    [SerializeField] private LayerMask PickUp;

    public ScreenState state = ScreenState.START_SCREEN;
    public GameObject hoverText1;
    public GameObject hoverText3;
    public GameObject hoverText4;
    public GameObject background;
    public GameObject startButton;
    public GameObject exitButton;
    public GameObject Player;
    public EndTriggerScript EndTrigger;

    CharacterController playerController;


    public ObjectGrabbable objectGrabbable;
    public PickUpScript_3 pickScript;
    public CabinetAnimation CabinetAnim;
    public SwitchAnimation SwitchAnim;
    public int screen = default;


    private float range;
    // Start is called before the first frame update

    //different screen states for the canvas
    public enum ScreenState 
    {
        START_SCREEN,

        MAIN_GAME,

        END_SCREEN,

    };

    void Start()
    {
        //determines the raycast range, grabs the player's character controller and hides all the prompts on the screen that might appear
        playerController = Player.GetComponent<CharacterController>();
        range = 2;
        HideAnimPrompts();
        HidePickUpPrompts();
    }

    // Update is called once per frame
    void Update()
    {
        //switch statement to determine the screens, enabling the cursor, player character controller, prompts and buttons to be displayed depending on the state
        if (state == ScreenState.START_SCREEN)
        {
            playerController.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            HidePickUpPrompts();
            HideAnimPrompts();
            exitButton.SetActive(false);
            background.SetActive(true);
            startButton.SetActive(true);
        }
        if (state == ScreenState.MAIN_GAME)
        {
            playerController.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            background.SetActive(false);
            startButton.SetActive(false);
        }
        if (state == ScreenState.END_SCREEN)
        {
            playerController.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            HidePickUpPrompts();
            HideAnimPrompts();
            background.SetActive(true);
            exitButton.SetActive(true);
        }
        
        //continuous raycast from the player's camera, which when detecting an animation object will play the animation if the E key is pressed
        Ray CameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(CameraRay, out RaycastHit hitAnim, range, Anim))
        {

            hoverText1.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hitAnim.transform.TryGetComponent(out CabinetAnim))
                {
                    CabinetAnim.PlayAnim();
                }
                if (hitAnim.transform.TryGetComponent(out SwitchAnim))
                {
                    SwitchAnim.PlaySwitchAnim();
                }
            }

        }

        else
        {
            HideAnimPrompts();
        }

        //an if statement to recognise if an object is currently being picked up, grabbing the info from isHeld bool to show the drop or pick up message
        if (Physics.Raycast(CameraRay, out RaycastHit hitPickup, range, PickUp))
        {
            if (hoverText4.activeSelf == false)
            {
                hoverText3.SetActive(true);

                if (pickScript.isHeld == true)
                {
                    hoverText3.SetActive(false);
                    hoverText4.SetActive(true);
                }
            }


        }
        else
        {
            HidePickUpPrompts();
        }
        //if statement to register whether the player walks through the end screen
        if(EndTrigger.PlayerEnter == true)
        {
            state = ScreenState.END_SCREEN;
        }
    }

    //functions to save having to repeat the functions every time a screen message needs to be hidden, making the code neater and less cluttered
    public void HideAnimPrompts()
    {
        hoverText1.SetActive(false);
    }

    public void HidePickUpPrompts()
    {
        hoverText3.SetActive(false);
        hoverText4.SetActive(false);
    }

    //functions for the start and exit buttons, which enable the character controller and end the application
    public void startButtonPress()
    {
        state = ScreenState.MAIN_GAME;
    }

    public void exitButtonPress()
    {
        Application.Quit();
    }




}



