using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
    public static mainMenuController MainMenu;
    public static exitGameController ExitGame;
    public static blocksManager blocks;
    public static arenaManager arena;
    public static nextBlocksController nextBlocks;
    public static GameObject Game;

    private static string gameVersion = "0.3.7";
    private static string lastUpdateTime = "30.07.2015";
	
	void Awake()
    {
        MainMenu = GameObject.FindObjectOfType<mainMenuController>();
        ExitGame = GameObject.FindObjectOfType<exitGameController>();
        blocks = GameObject.FindObjectOfType<blocksManager>();
        arena = GameObject.FindObjectOfType<arenaManager>();
        nextBlocks = GameObject.FindObjectOfType<nextBlocksController>();
        Game = GameObject.FindGameObjectWithTag("Game");

        ExitGame.setActive(false);
        Game.SetActive(false);
    }
}
