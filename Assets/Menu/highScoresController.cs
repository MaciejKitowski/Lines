using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class highScoresController : utilities 
{
    private Text[] place;
    private mainMenuController mainMenu;
    private List<KeyValuePair<string, int>> Score;

    void Awake()
    {
        //PlayerPrefs.DeleteAll(); // ---------- [DEBUG] ----------
        place = new Text[10];

        for (int i = 0; i < 10; ++i) place[i] = gameObject.transform.GetChild(i + 1).gameObject.GetComponent<Text>();
        mainMenu = GameObject.FindGameObjectWithTag("Main Menu").GetComponent<mainMenuController>();
        Score = new List<KeyValuePair<string, int>>();
        loadScore();
    }
    void Start() { setActive(false); }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.setActive(true);
            setActive(false);
        }
    }

    public bool compareWithlastScore(int val)
    {
        if (val > Score[9].Value) return true;
        else return false;
    }

    public void newHighScore(int val)
    {
        Score[9] = new KeyValuePair<string, int>(DateTime.Now.ToString("yyyy/MM/dd HH:mm"), val);
        sortScore();
    }

    public void updateText() { for (int i = 0; i < 10; ++i) place[i].text = (i + 1).ToString() + ". " + Score[i].Key + " " + Score[i].Value.ToString(); }

    private void loadScore()
    {
        if (PlayerPrefs.HasKey("Scores"))
        {
            for (int i = 0; i < 10; ++i)
            {
                string str = PlayerPrefs.GetString("dateSCR" + (i + 1).ToString());
                int val = PlayerPrefs.GetInt("valueSCR" + (i + 1).ToString());

                Score.Add(new KeyValuePair<string, int>(str, val));
            }
        }
        else createPlayerPrefs();
        sortScore();
    }

    private void saveScore()
    {
        if (PlayerPrefs.HasKey("Scores"))
        {
            for (int i = 0; i < 10; ++i)
            {
                PlayerPrefs.SetString("dateSCR" + (i + 1).ToString(), Score[i].Key);
                PlayerPrefs.SetInt("valueSCR" + (i + 1).ToString(), Score[i].Value);
            }
        }
        PlayerPrefs.Save();
    }

    private void createPlayerPrefs()
    {
        PlayerPrefs.SetInt("Scores", 1);

        for (int i = 0; i < 10; ++i)
        {
            PlayerPrefs.SetString("dateSCR" + (i + 1).ToString(), DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            PlayerPrefs.SetInt("valueSCR" + (i + 1).ToString(), (i + 1));
        }
        loadScore();
    }

    private void sortScore() { Score.Sort((nextPair, firstPair) => { return firstPair.Value.CompareTo(nextPair.Value); }); }
	
    public void button_back()
    {
        saveScore();
        mainMenu.setActive(true);
        setActive(false);
    }
}
