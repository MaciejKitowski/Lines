using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour 
{
    public static int points = 0;

    public static blockManager blocks;
    public static arenaManager arena;
    public static nextBlocksController nextBlock;
    public static debugMenu DebugMenu;
    public static mainMenuController mainMenu;
	
	void Awake () 
    {
        blocks = FindObjectOfType<blockManager>();
        arena = FindObjectOfType<arenaManager>();
        nextBlock = FindObjectOfType<nextBlocksController>();
        DebugMenu = FindObjectOfType<debugMenu>();
        mainMenu = FindObjectOfType<mainMenuController>();
	}
}
