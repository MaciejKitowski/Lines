using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class aboutController : MonoBehaviour 
{
    public bool active = true;
    public string createdBy;
    public string gameVersion;
    public string lastUpdate;

    private Text UIcreatedBy;
    private Text UIgameVersion;
    private Text UIlastUpdate;
	
	void Awake()
    {
        UIcreatedBy = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        UIgameVersion = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        UIlastUpdate = gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        if (checkValue()) updateValues();
        else Debug.LogError("About - To short string values in controller.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Back button");
            Manager.MainMenu.setActive(true);
            setActive(false);
        }
    }

    public void setActive(bool status)
    {
        active = status;
        gameObject.SetActive(status);
    }

    private bool checkValue()
    {
        if (createdBy.Length < 3 || gameVersion.Length < 3 || lastUpdate.Length < 3) return false;
        else return true;
    }

    private void updateValues()
    {
        UIcreatedBy.text = createdBy;
        UIgameVersion.text = gameVersion;
        UIlastUpdate.text = lastUpdate;
    }

    public void button_back()
    {
        Debug.Log("Back button");
        Manager.MainMenu.setActive(true);
        setActive(false);
    }
}
