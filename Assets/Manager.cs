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
    public static highScoresController highScore;
    public static endGameController endGame;
	
	void Awake()
    {
        MainMenu = GameObject.FindObjectOfType<mainMenuController>();
        ExitGame = GameObject.FindObjectOfType<exitGameController>();
        blocks = GameObject.FindObjectOfType<blocksManager>();
        arena = GameObject.FindObjectOfType<arenaManager>();
        about = GameObject.FindObjectOfType<aboutController>();
        nextBlocks = GameObject.FindObjectOfType<nextBlocksController>();
        highScore = GameObject.FindObjectOfType<highScoresController>();
        endGame = GameObject.FindObjectOfType<endGameController>();
        Game = GameObject.FindGameObjectWithTag("Game");
        
        ExitGame.setActive(false);
        Game.SetActive(false);
        about.setActive(false);
        highScore.setActive(false);
        endGame.setActive(false);
    }
}
