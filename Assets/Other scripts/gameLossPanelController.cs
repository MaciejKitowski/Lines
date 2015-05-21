using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameLossPanelController : MonoBehaviour
{
    public bool active;

    private GameObject newRecord;
    private Text pointsValue;
    private GameObject canvas;

	void Start () 
    {
        canvas = gameObject.transform.GetChild(0).gameObject;

        pointsValue = canvas.transform.GetChild(5).gameObject.GetComponent<Text>();
        newRecord = canvas.transform.GetChild(6).gameObject;

        newRecord.SetActive(false);
        canvas.SetActive(false);
	}

    void Update()
    {
        if (!active && manager.readyToHide(ref canvas)) canvas.gameObject.SetActive(false);
    }

    public void display()
    {
        active = true;
        manager.displayObject(ref canvas);
        pointsValue.text = manager.points.ToString();

        if (manager.points > scoreManager.Score[9].Value)
        {
            newRecord.SetActive(true);
            scoreManager.addNewRecord(manager.points);
        }
    }

    public void resetGameBUTTON()
    {
        active = false;
        newRecord.SetActive(false);
        manager.points = 0;
        manager.hideObject(ref canvas);
        manager.blocks.deleteAllBlocks();
    }

    public void backToMenuBUTTON()
    {
        manager.points = 0;
        active = false;
        newRecord.SetActive(false);
        canvas.SetActive(false);
        manager.blocks.deleteAllBlocks();
    
        manager.menu.mainMenu.display();
    }
}
