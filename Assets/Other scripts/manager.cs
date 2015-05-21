using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour 
{
    public static int points = 0;

    public static blockManager blocks;
    public static arenaManager arena;
    public static nextBlocksController nextBlock;
    public static debugMenu DebugMenu;
    public static menuManager menu;
    public static versionInfo verInfo;
    public static gameLossPanelController gameLossPanel;
	
	void Awake () 
    {
        blocks = FindObjectOfType<blockManager>();
        arena = FindObjectOfType<arenaManager>();
        nextBlock = FindObjectOfType<nextBlocksController>();
        DebugMenu = FindObjectOfType<debugMenu>();
        menu = FindObjectOfType<menuManager>();
        verInfo = FindObjectOfType<versionInfo>();
        gameLossPanel = FindObjectOfType<gameLossPanelController>();
	}

    public static void displayObject(ref GameObject obj)
    {
        obj.SetActive(true);
        obj.GetComponent<Animator>().SetTrigger("display");
    }

    public static void hideObject(ref GameObject obj)
    {
        obj.GetComponent<Animator>().SetTrigger("hide");
    }

    public static bool readyToHide(ref GameObject obj)
    {
        if (obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("readyToHide")) return true;
        else return false;
    }

    public static bool isIdle(ref GameObject obj)
    {
        if (obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle")) return true;
        else return false;
    }
}
