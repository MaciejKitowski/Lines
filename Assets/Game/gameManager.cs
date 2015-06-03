using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour 
{
    private static blockManager blocks;
    private static arenaManager arena;
    private static nextBlocksController nextBlock;
    private static debugMenu debugmenu;
    private static gameLossPanelController gameLossPanel;

	void Awake () 
    {
        blocks = FindObjectOfType<blockManager>();
        arena = FindObjectOfType<arenaManager>();
        nextBlock = FindObjectOfType<nextBlocksController>();
        debugmenu = FindObjectOfType<debugMenu>();
        gameLossPanel = FindObjectOfType<gameLossPanelController>();
	}
	
	public static blockManager BlockManager() { return blocks; }
    public static arenaManager ArenaManager() { return arena; }
    public static nextBlocksController NextBlockControl() { return nextBlock; }
    public static debugMenu DebugMenu() { return debugmenu; }
    public static gameLossPanelController GameLossPanel() { return gameLossPanel; }
}
