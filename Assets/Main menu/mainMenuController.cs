using UnityEngine;
using System.Collections;

public class mainMenuController : MonoBehaviour 
{
    public bool active;

    GameObject HighScores;
    public bool displayHighScores;

    GameObject about;
    public bool displayAbout;

    GameObject exitPanel;
    public bool displayExitPanel;

	void Start () 
    {
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
            HighScores.SetActive(false);
        }
	}

    public void displayMenu()
    {
        active = true;
        gameObject.SetActive(true);
    }

    public void hideMenu()
    {
        active = false;
        gameObject.SetActive(false);
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
            HighScores.SetActive(true);
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
