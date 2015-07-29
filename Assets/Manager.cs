using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
    public static mainMenuController MainMenu;
    public static exitGameController ExitGame;
    public static blocksManager blocks;
    public static arenaManager arena;
    public static nextBlocksController nextBlocks;

    private static string gameVersion = "0.3.2";
    private static string lastUpdateTime = "29.07.2015";
	
	void Awake()
    {
        MainMenu = GameObject.FindObjectOfType<mainMenuController>();
        ExitGame = GameObject.FindObjectOfType<exitGameController>();
        blocks = GameObject.FindObjectOfType<blocksManager>();
        arena = GameObject.FindObjectOfType<arenaManager>();
        nextBlocks = GameObject.FindObjectOfType<nextBlocksController>();

        ExitGame.setActive(false);
    }
}
