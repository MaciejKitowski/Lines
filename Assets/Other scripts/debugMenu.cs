using UnityEngine;
using System.Collections;

public class debugMenu : MonoBehaviour 
{
    public bool active = false;

    void Update() { if (Input.GetKeyDown(KeyCode.Escape) && !manager.mainMenu.active) toggleDisplay(); }

    public void addPoints() { manager.points += 100; } //Add 100 points
    public void substractPoints() { manager.points -= 100; } //Substract 100 points
    public void randNew() { manager.nextBlock.randNewColor(); } //Rand new nextBlocks colors

    //Exit game button
    public void exitGame() 
    {
        scoreManager.saveScore();
        Application.Quit();
    }
    
    //Display/hide
    private void toggleDisplay()
    {
        if(active) gameObject.transform.GetChild(0).gameObject.SetActive(false);
        else gameObject.transform.GetChild(0).gameObject.SetActive(true);
        active = !active;
    }

    //Push new blocks
    public void pushBlocks()
    {
        manager.nextBlock.blocksToAdd = 4;
        toggleDisplay();
    }

    //Back to menu button
    public void backToMenu()
    {
        toggleDisplay();
        manager.gameLossPanel.activate();
        //manager.mainMenu.displayMenu();
    }

    //Delete all blocks
    public void deleteBlocks()
    {
        for (int i = manager.blocks.blockCount() - 1; i >= 0; --i) manager.blocks.deleteBlock(manager.blocks.getBlock(i));
        toggleDisplay();
    }
}
