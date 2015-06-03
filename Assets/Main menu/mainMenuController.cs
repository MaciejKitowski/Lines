using UnityEngine;
using System.Collections;

public class mainMenuController : MonoBehaviour 
{
    public bool active;

    private GameObject canvas;

	void Start () 
    {
        active = true;
        canvas = gameObject.transform.GetChild(0).gameObject;
	}
	
	void Update () 
    {
        if (active && manager.readyToHide(ref canvas))
        {
            canvas.gameObject.SetActive(false);
            active = false;
        }

        if(manager.isIdle(ref canvas))
        {
            if (Input.GetKeyDown(KeyCode.Escape)) menuManager.ExitGame().display();
        }
	}

    public void display()
    {
        active = true;
        manager.displayObject(ref canvas);
    }

    public void hide()
    {
        manager.hideObject(ref canvas);
    }

    public void newGameBUTTON()
    {
        if (manager.isIdle(ref canvas)) hide();
    }

    public void exitGameBUTTON()
    {
        if (manager.isIdle(ref canvas)) menuManager.ExitGame().display();
    }

    public void highScoresBUTTON()
    {
        if (manager.isIdle(ref canvas)) menuManager.HighScores().display();
    }

    public void aboutBUTTON()
    {
        if (manager.isIdle(ref canvas)) menuManager.About().display();
    }
}
