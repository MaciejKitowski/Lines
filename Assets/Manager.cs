using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
    public static mainMenuController MainMenu;
    public static exitGameController ExitGame;

    private static string gameVersion = "0.2.6";
    private static string lastUpdateTime = "24.07.2015";
	
	void Awake()
    {
        MainMenu = GameObject.FindObjectOfType<mainMenuController>();
        ExitGame = GameObject.FindObjectOfType<exitGameController>();

        ExitGame.setActive(false);
    }
}
