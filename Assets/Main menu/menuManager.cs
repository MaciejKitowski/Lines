using UnityEngine;
using System.Collections;

public class menuManager : MonoBehaviour 
{
    public mainMenuController mainMenu;
    public exitGameController exitGame;
    public highScoresController highScores;
    public aboutController about;

	void Start () 
    {
        mainMenu = gameObject.transform.GetChild(0).gameObject.GetComponent<mainMenuController>();
        exitGame = gameObject.transform.GetChild(1).gameObject.GetComponent<exitGameController>();
        highScores = gameObject.transform.GetChild(2).gameObject.GetComponent<highScoresController>();
        about = gameObject.transform.GetChild(3).gameObject.GetComponent<aboutController>();
	}
}
