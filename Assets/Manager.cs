using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour 
{
    public static mainMenuController MainMenu;
    public static blocksManager blocks;
    public static arenaManager arena;
    public static nextBlocksController nextBlocks;
    public static GameObject Game;
    public static highScoresController highScore;
    public static endGameController endGame;
    public static debugMenuController debugMenu;
	
	void Awake()
    {
        MainMenu = GameObject.FindObjectOfType<mainMenuController>();
        blocks = GameObject.FindObjectOfType<blocksManager>();
        arena = GameObject.FindObjectOfType<arenaManager>();
        nextBlocks = GameObject.FindObjectOfType<nextBlocksController>();
        highScore = GameObject.FindObjectOfType<highScoresController>();
        endGame = GameObject.FindObjectOfType<endGameController>();
        debugMenu = GameObject.FindObjectOfType<debugMenuController>();
        Game = GameObject.FindGameObjectWithTag("Game");
        
        Game.SetActive(false);
        endGame.setActive(false);
        debugMenu.setActive(false);
    }
}
