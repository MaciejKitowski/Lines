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
    public static aboutController about;
	
	void Awake()
    {
        MainMenu = GameObject.FindObjectOfType<mainMenuController>();
        ExitGame = GameObject.FindObjectOfType<exitGameController>();
        blocks = GameObject.FindObjectOfType<blocksManager>();
        arena = GameObject.FindObjectOfType<arenaManager>();
        about = GameObject.FindObjectOfType<aboutController>();
        nextBlocks = GameObject.FindObjectOfType<nextBlocksController>();
        Game = GameObject.FindGameObjectWithTag("Game");
        

        Debug.Log(MainMenu.gameObject.name);
        ExitGame.setActive(false);
        Game.SetActive(false);
        about.setActive(false);
    }
}
