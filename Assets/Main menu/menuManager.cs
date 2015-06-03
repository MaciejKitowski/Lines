using UnityEngine;
using System.Collections;

public class menuManager : MonoBehaviour 
{
    private static mainMenuController mainMenu;
    private static exitGameController exitGame;
    private static highScoresController highScores;
    private static aboutController about;

	void Start () 
    {
        mainMenu = gameObject.transform.GetChild(0).gameObject.GetComponent<mainMenuController>();
        exitGame = gameObject.transform.GetChild(1).gameObject.GetComponent<exitGameController>();
        highScores = gameObject.transform.GetChild(2).gameObject.GetComponent<highScoresController>();
        about = gameObject.transform.GetChild(3).gameObject.GetComponent<aboutController>();
	}

    public static mainMenuController MainMenu()
    {
        return mainMenu;
    }

    public static exitGameController ExitGame()
    {
        return exitGame;
    }

    public static highScoresController HighScores()
    {
        return highScores;
    }

    public static aboutController About()
    {
        return about;
    }
}
