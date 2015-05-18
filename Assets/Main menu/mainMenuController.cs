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
	}
	
	void Update () 
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!displayHighScores && !displayAbout && !displayExitPanel) displayExit();
            else if (displayExitPanel) exitNoButton();
        }
	}

    //New game
    public void newGame()
    {
        if(!displayHighScores && !displayAbout && !displayExitPanel)
        {
            active = false;
            gameObject.SetActive(false);
        }
    }

    //Exit game panel
    public void displayExit()
    {
        if (!displayHighScores && !displayAbout && !displayExitPanel)
        {
            displayExitPanel = true;
            exitPanel.SetActive(true);
        }
    }

    public void exitYesButton()
    {
        Application.Quit();
    }

    public void exitNoButton()
    {
        displayExitPanel = false;
        exitPanel.SetActive(false);
    }
}
