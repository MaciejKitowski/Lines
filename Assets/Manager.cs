using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
    public static mainMenuController MainMenu;
    public static exitGameController ExitGame;
    public static blocksManager blocks;

    private static string gameVersion = "0.2.9";
    private static string lastUpdateTime = "28.07.2015";
	
	void Awake()
    {
        MainMenu = GameObject.FindObjectOfType<mainMenuController>();
        ExitGame = GameObject.FindObjectOfType<exitGameController>();
        blocks = GameObject.FindObjectOfType<blocksManager>();

        ExitGame.setActive(false);
    }
}
