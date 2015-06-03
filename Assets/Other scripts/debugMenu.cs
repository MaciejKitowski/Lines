using UnityEngine;
using System.Collections;

public class debugMenu : MonoBehaviour 
{
    public bool active = false;

    void Update() { if (Input.GetKeyDown(KeyCode.Escape) && !menuManager.MainMenu().active) toggleDisplay(); }

    public void addPoints() { PointsController.addPoints(100); } //Add 100 points
    public void substractPoints() { PointsController.substractPoints(100); } //Substract 100 points
    public void randNew() { gameManager.NextBlockControl().randNewColor(); } //Rand new nextBlocks colors

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
        gameManager.NextBlockControl().blocksToAdd = 4;
        toggleDisplay();
    }

    //Back to menu button
    public void backToMenu()
    {
        toggleDisplay();
        gameManager.GameLossPanel().display();
    }

    //Delete all blocks
    public void deleteBlocks()
    {
        for (int i = gameManager.BlockManager().blockCount() - 1; i >= 0; --i) gameManager.BlockManager().deleteBlock(gameManager.BlockManager().getBlock(i));
        toggleDisplay();
    }
}
