using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //sound
    public AudioSource source;
    public AudioClip buttonPress;
    
    //menu control images
    public GameObject[] KeyboardInstucts;
    public GameObject[] ControllerInstructs;
    public bool keyboard = false;

    //in game control images
    public GameObject KeyboardInGameControls;
    //public GameObject ControllerInGameControls;    

    //keep track of scenes
    Scene mainmenu;
    Scene credit;
    Scene tutorial;

    private void Start()
    {
        mainmenu = SceneManager.GetSceneByName("MainMenu");
        tutorial = SceneManager.GetSceneByName("Tutorial");
        credit = SceneManager.GetSceneByName("Credits");
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw("MainMenu") == 1)
        {
            MainMenu();
        }        

        if (Input.GetAxisRaw("ExitGame") == 1)
        {
            ExitGame();
        }

        if (SceneManager.GetActiveScene() == mainmenu && Input.GetAxisRaw("Credits") == 1)
        {
            CreditScene();
        }

        if(SceneManager.GetActiveScene() == mainmenu || SceneManager.GetActiveScene() == credit)
        {
            if (Input.GetAxisRaw("PlayGame") == 1)
            {
                PlayGame();
            }
        }        
    }

    public void ExitGame()
    {
        source.PlayOneShot(buttonPress);
        Application.Quit();
    }

    public void PlayGame()
    {
        source.PlayOneShot(buttonPress);
        SceneManager.LoadScene(1);
    }

    public void CreditScene()
    {
        source.PlayOneShot(buttonPress);
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        source.PlayOneShot(buttonPress);
        SceneManager.LoadScene("MainMenu");
    }

    //public void KeyboardInput()
    //{
    //    if(keyboard == false)
    //    {
    //        if(SceneManager.GetActiveScene() == mainmenu || SceneManager.GetActiveScene() == credit)
    //        {
    //            foreach (GameObject k in KeyboardInstucts)
    //            {
    //                k.SetActive(true);
    //            }

    //            foreach (GameObject c in ControllerInstructs)
    //            {
    //                c.SetActive(false);
    //            }
    //        }
    //        else if(SceneManager.GetActiveScene() == tutorial)
    //        {
    //            foreach (GameObject k in KeyboardInstucts)
    //            {
    //                k.SetActive(true);
    //            }

    //            foreach (GameObject c in ControllerInstructs)
    //            {
    //                c.SetActive(false);
    //            }

    //            KeyboardInGameControls.SetActive(true);
    //            ControllerInGameControls.SetActive(false);
    //        }
    //        else
    //        {
    //            KeyboardInGameControls.SetActive(true);
    //            ControllerInGameControls.SetActive(false);

    //            keyboard = true;
    //        }

    //        keyboard = true;
    //    }             
    //}

    //public void ControllerInput()
    //{
    //    if (keyboard)
    //    {
    //        if (SceneManager.GetActiveScene() == mainmenu || SceneManager.GetActiveScene() == credit)
    //        {
    //            foreach (GameObject c in ControllerInstructs)
    //            {
    //                c.SetActive(true);
    //            }

    //            foreach (GameObject k in KeyboardInstucts)
    //            {
    //                k.SetActive(false);
    //            }
    //        }
    //        else if(SceneManager.GetActiveScene() == tutorial)
    //        {
    //            foreach (GameObject c in ControllerInstructs)
    //            {
    //                c.SetActive(true);
    //            }

    //            foreach (GameObject k in KeyboardInstucts)
    //            {
    //                k.SetActive(false);
    //            }

    //            KeyboardInGameControls.SetActive(false);
    //            ControllerInGameControls.SetActive(true);
    //        }
    //        else
    //        {
    //            KeyboardInGameControls.SetActive(false);
    //            ControllerInGameControls.SetActive(true);
    //        }

    //        keyboard = false;
    //    }        
    //}
}
