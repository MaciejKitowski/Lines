using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class gameLossPanelController : MonoBehaviour
{
    public bool active;
    private GameObject newRecord;
    private Text pointsValue;

	void Start () 
    {
        pointsValue = gameObject.transform.GetChild(0).transform.GetChild(5).gameObject.GetComponent<Text>();
        newRecord = gameObject.transform.GetChild(0).transform.GetChild(6).gameObject;
        newRecord.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
	}

    void Update()
    {
        //Hide Game loss panel if animation has ended
        if (!active && gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("readyToHide"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void displayGameLoss()
    {
        active = true;
        pointsValue.text = manager.points.ToString();

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("displayGameLossPanel");

        if (manager.points > scoreManager.Score[9].Value)
        {
            newRecord.SetActive(true);
            scoreManager.Score[9] = new KeyValuePair<string, int>(DateTime.Now.ToString("yyyy/MM/dd HH:mm"), manager.points);
            scoreManager.sortScore();
        }
    }
	
    public void resetGame()
    {
        manager.points = 0;
        active = false;
        newRecord.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("hideGameLossPanel");

        //Delete all blocks
        for (int i = manager.blocks.blockCount() - 1; i >= 0; --i) manager.blocks.deleteBlock(manager.blocks.getBlock(i));
    }

    public void backToMenu()
    {
        manager.points = 0;
        active = false;
        newRecord.SetActive(false);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        //Delete all blocks
        for (int i = manager.blocks.blockCount() - 1; i >= 0; --i) manager.blocks.deleteBlock(manager.blocks.getBlock(i));
    
        manager.mainMenu.displayMenu();
    }
}
