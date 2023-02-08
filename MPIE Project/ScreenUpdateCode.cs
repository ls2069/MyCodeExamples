using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenUpdateCode : MonoBehaviour
{
    public ScreenState state = ScreenState.START_SCREEN;

    public GameObject Player; //these lines of code access the Player's gameobject other UI elements that are attached to the canvas
    public GameObject PlayerModel;
    public GameObject RestartButton;
    public GameObject QuitButton;
    public GameObject StartScreen;
    public GameObject WinScreen;
    public GameObject DeathScreen;

    CharacterController PlayerHitbox;
    ThirdPersonController PlayerMovement;

    public KeyCollectScript KeyNum;

    public Button StartButton;



    public enum ScreenState // the enumerator has 4 states, all of which are assigned conditions in the update method
    {
        START_SCREEN,
        
        PLAY_SCREEN,

        WIN_SCREEN,

        DEATH_SCREEN,

    };
    // Start is called before the first frame update
    void Start()
    {

        PlayerHitbox = Player.GetComponent<CharacterController>(); //these lines of code access the player's character controller code and movement in order to disable them during different screens
        PlayerMovement = Player.GetComponent<ThirdPersonController>();



    }

    // Update is called once per frame
    void Update()
    {
        float healthVal = Player.GetComponent<PlayerHealthScript>().health; //these take the values of the number of keys and the health the player has to determine which screen needs to be shown
        int keyVal = Player.GetComponent<KeyCollectScript>().currentKeyCount;

        

        if (state == ScreenState.START_SCREEN) //code to add the play and quit buttons with the start screen raw image, while unlocking the mouse and removing the player so the user interacts with the screen without affecting things in the background
        {
            RemovePlayer();
            StartScreen.SetActive(true);
            WinScreen.SetActive(false);
            DeathScreen.SetActive(false);
            CursorUnlockCode();
            QuitButton.SetActive(true);
            RestartButton.SetActive(false);

        }

        if (state == ScreenState.PLAY_SCREEN) //code to remove the start screen raw image and lock the user's mouse, at the same time adding the player into the environment so the user can play the game
        {
            AddPlayer();
            StartScreen.SetActive(false);
            CursorLockCode();
            RestartButton.SetActive(false);
            QuitButton.SetActive(false);
        }

        if (state == ScreenState.DEATH_SCREEN) //code to add the restart and quit buttons with the death screen raw image, while unlocking the mouse and removing the player so the user interacts with the screen without affecting things in the background
        {
            RestartButton.SetActive(true);
            DeathScreen.SetActive(true);
            StartScreen.SetActive(false);
            QuitButton.SetActive(true);
            CursorUnlockCode();
            RemovePlayer();
        }

        if (healthVal <= 0)
        {
            state = ScreenState.DEATH_SCREEN; //sets the state to DEATH_SCREEN when the player's health is below or equal to 0
        }

        if (keyVal >= 3)
        {
            state = ScreenState.WIN_SCREEN; //sets the state to WIN_SCREEN when the player collects 3 keys
        }


        if (state == ScreenState.WIN_SCREEN)
        {
            RestartButton.SetActive(true);
            WinScreen.SetActive(true);
            QuitButton.SetActive(true);
            CursorUnlockCode();
            RemovePlayer();
        }
        
    }

    void CursorUnlockCode() //function to unlock the user's mouse
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    void CursorLockCode() //function to lock the user's mouse
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void AddPlayer() //function to set the attributes of the player as true so the camera remains and the player + it's controls disappear during certain screens
    {
        PlayerModel.SetActive(true);
        PlayerHitbox.enabled = true;
        PlayerMovement.enabled = true;
    }

    void RemovePlayer() //function to remove the player's attributes 
    {
        PlayerModel.SetActive(false);
        PlayerHitbox.enabled = false;
        PlayerMovement.enabled = false;
    }

    public void StartButtonClicked() //code to switch the state to the play screen when the START button is pressed
    {
        state = ScreenState.PLAY_SCREEN;
    }

    public void RestartButtonClicked() //code to restart the scene when the RESTART button is pressed
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitButtonClicked() //code to exit the application when the QUIT button is pressed
    {
        Application.Quit();
    }
}
