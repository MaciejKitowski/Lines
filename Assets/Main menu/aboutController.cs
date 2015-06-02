using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class aboutController : MonoBehaviour 
{
    public bool active;

    public GameObject canvas;
	
	void Start () 
    {
        canvas = gameObject.transform.GetChild(0).gameObject;
        canvas.SetActive(false);

        canvas.transform.GetChild(5).gameObject.GetComponent<Text>().text = manager.verInfo.gameVersion;
        canvas.transform.GetChild(7).gameObject.GetComponent<Text>().text = manager.verInfo.lastUpdateTime;
	}
	
	
	void Update () 
    {
        if (active && manager.readyToHide(ref canvas))
        {
            active = false;
            canvas.gameObject.SetActive(false);
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

    public void returnBUTTON()
    {
        hide();
    }
}
