using UnityEngine;
using System.Collections;

public class mainMenuController : MonoBehaviour 
{
    public bool active;

    GameObject mainMenu;

    GameObject HighScores;
    public bool displayHighScores;

    GameObject about;
    public bool displayAbout;

    GameObject exitPanel;
    public bool displayExitPanel;

	void Start () 
    {
        mainMenu = gameObject.transform.GetChild(0).gameObject;
        exitPanel = gameObject.transform.GetChild(1).gameObject;
        HighScores = gameObject.transform.GetChild(2).gameObject;
	}
	
	void Update () 
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!displayHighScores && !displayAbout && !displayExitPanel) displayExit();
            else if (displayExitPanel) exitNoButton();
        }

        //Display Main menu if animation has ended
        if (!active && mainMenu.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            active = true;
        }

        //Hide Main menu if animation has ended
        if (active && mainMenu.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("readyToHide"))
        {
            active = false;
            gameObject.SetActive(false);
        }

        //Hide exit panel if animation has ended
        if (displayExitPanel && exitPanel.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("readyToHide"))
        {
            displayExitPanel = false;
            exitPanel.SetActive(false);
        }

        //Hide High Scores panel if animation has ended
        if(displayHighScores && HighScores.GetComponent<highScoresController>().getAnim().GetCurrentAnimatorStateInfo(0).IsName("readyToHide"))
        {
            displayHighScores = false;
            HighScores.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
	}

    public void displayMenu()
    {
        gameObject.SetActive(true);
        mainMenu.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("displayMainMenu");
    }

    public void hideMenu()
    {
        mainMenu.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("hideMainMenu");
    }

    //New game
    public void newGame()
    {
        if (!displayHighScores && !displayAbout && !displayExitPanel) hideMenu();
    }

    public void highScoresButton()
    {
        if (!displayHighScores && !displayAbout && !displayExitPanel)
        {
            displayHighScores = true;
            HighScores.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            highScoresController.updateScores();
            HighScores.GetComponent<highScoresController>().getAnim().SetTrigger("displayHighScores");
        }
    }

    //Exit game panel
    public void displayExit()
    {
        if (!displayHighScores && !displayAbout && !displayExitPanel)
        {
            displayExitPanel = true;
            exitPanel.SetActive(true);
            exitPanel.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("displayExit"); //Run animation
        }
    }
    
    public void exitYesButton()
    {
        if (exitPanel.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            scoreManager.saveScore();
            Application.Quit();
        }
    }

    public void exitNoButton()
    {
        if (exitPanel.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            exitPanel.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("hideExit"); //Run animation
        }
    }
}
