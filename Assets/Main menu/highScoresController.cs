using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highScoresController : MonoBehaviour 
{
    public bool active;

    public GameObject canvas;

    private static Text[] place;

    void Start()
    {
        place = new Text[10];

        for (int i = 0, j = 2; i < 10; ++i, ++j) place[i] = gameObject.transform.GetChild(0).gameObject.transform.GetChild(j).gameObject.GetComponent<Text>();

        canvas = gameObject.transform.GetChild(0).gameObject;
        canvas.SetActive(false);
    }

    void Update()
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
        updateScores();
    }

    public void hide()
    {
        manager.hideObject(ref canvas);
    }

    public void returnBUTTON()
    {
        hide();
    }

    private void updateScores()
    {
        for (int i = 0, j = 1; i < 10; ++i, ++j)
        {
            if (place[i] != null) place[i].text = j.ToString() + ". " + scoreManager.Score[i].Key + " " + scoreManager.Score[i].Value.ToString();
        }
    }
}
