using UnityEngine;
using System.Collections;

public class exitGameController : MonoBehaviour 
{
    public bool active;

    private GameObject canvas;

	void Start () 
    {
        canvas = gameObject.transform.GetChild(0).gameObject;
        canvas.SetActive(false);
	}

	void Update () 
    {
        if (active && manager.readyToHide(ref canvas))
        {
            active = false;
            canvas.SetActive(false);
        }

        if (manager.isIdle(ref canvas))
        {
            if (Input.GetKeyDown(KeyCode.Escape)) hide();
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

    public void YesBUTTON()
    {
        if (manager.isIdle(ref canvas))
        {
            scoreManager.saveScore();
            Application.Quit();
        }
    }

    public void NoBUTTON()
    {
        if (manager.isIdle(ref canvas)) hide();
    }
}
